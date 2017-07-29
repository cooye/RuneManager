﻿using RuneOptim;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RuneApp {

	// Generates a bunch of builds to preview the stats
	public partial class Generate : Form
	{
		// the build to use
		public Build build;

		// if making builds
		bool building;

		public Generate(Build bb)
		{
			InitializeComponent();

			loadoutList.SetDoubleBuffered();
			
			// master has given Gener a Build?
			build = bb;
			Label label;
			TextBox textBox;

			// cool clicky thing
			var sorter = new ListViewSort();
			// sort decending on POINTS
			sorter.OnColumnClick(0, false);
			loadoutList.ListViewItemSorter = sorter;
			
			// place controls in a nice grid-like manner
			int x, y;

			y = 20;
			foreach (string stat in Build.statNames)
			{
				x = 25;
				label = groupBox1.Controls.MakeControl<Label>(stat, "Label", x, y, text: stat);
				x += 45;

				textBox = groupBox1.Controls.MakeControl<TextBox>(stat, "Worth", x, y);
				if (build.Sort[stat] != 0)
					textBox.Text = build.Sort[stat].ToString();
				textBox.TextChanged += textBox_TextChanged;

				y += 22;

				loadoutList.Columns.Add(stat).Width = 80;
			}
			foreach (string extra in Build.extraNames)
			{
				x = 25;
				label = groupBox1.Controls.MakeControl<Label>(extra, "Label", x, y, text: extra);
				x += 45;

				textBox = groupBox1.Controls.MakeControl<TextBox>(extra, "Worth", x, y);
				if (build.Sort.ExtraGet(extra) != 0)
					textBox.Text = build.Sort.ExtraGet(extra).ToString();
				textBox.TextChanged += textBox_TextChanged;

				y += 22;

				loadoutList.Columns.Add(extra).Width = 80;
			}
			loadoutList.Columns.Add("Skill1").Width = 80;
			loadoutList.Columns.Add("Skill2").Width = 80;
			loadoutList.Columns.Add("Skill3").Width = 80;
			loadoutList.Columns.Add("Skill4").Width = 80;
			
			toolStripStatusLabel1.Text = "Press 'Run' to begin.";
			building = true;
			toolStripProgressBar1.Maximum = Program.Settings.TestShow;

			build.loads.CollectionChanged += Loads_CollectionChanged;

			foreach (var b in build.loads)
			{
				loadoutList.Items.Add(renderLoadoutTest(b));
			}
			
			// Disregard locked, but honor equippedness checking
			build.BuildPrintTo += Build_BuildPrintTo;
			build.BuildProgTo += Build_BuildProgTo;
		}

		private void Build_BuildProgTo(object sender, ProgToEventArgs e)
		{
			if (!IsDisposed && IsHandleCreated)
			{
				Invoke((MethodInvoker)delegate
				{
					toolStripProgressBar1.Value = (int)(e.Percent * Program.Settings.TestShow);
					toolStripStatusLabel1.Text = "Generated " + e.Progress + " so far...";
				});
			}
			else
			{
				//build.isRun = false;
			}
		}

		private void Build_BuildPrintTo(object sender, PrintToEventArgs e)
		{
			
		}

		private void Loads_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
					foreach (var b in e.NewItems.Cast<Monster>())
					{
						if (!IsDisposed && IsHandleCreated)
						{
							// put the thing in on the main thread and bump the progress bar
							Invoke((MethodInvoker)delegate {
								var ll = renderLoadoutTest(b);
								loadoutList.Items.Add(ll);
							});
						}
					}
					break;
				case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
					foreach (var b in e.OldItems.Cast<Monster>())
					{
						Invoke((MethodInvoker)delegate
						{
							var lvi = loadoutList.Items.Cast<ListViewItem>().FirstOrDefault(l => l.Tag == b);
							lvi.Remove();
						});
					}
					break;
				case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
						Invoke((MethodInvoker)delegate { loadoutList.Items.Clear(); });
					break;
				case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
				case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
				default:
					throw new NotImplementedException();
			}
		}

		private ListViewItem renderLoadoutTest(Monster m)
		{
			ListViewItem li = new ListViewItem();
			var Cur = m.GetStats();

			int underSpec = 0;
			int under12 = 0;
			foreach (var r in m.Current.Runes)
			{
				if (r.Level < 12)
					under12 += 12 - r.Level;
				if (build.runePrediction.ContainsKey((SlotIndex)r.Slot) && r.Level < (build.runePrediction[(SlotIndex)r.Slot].Key ?? 0))
					underSpec += (build.runePrediction[(SlotIndex)r.Slot].Key ?? 0) - r.Level;
			}

			li.SubItems.Add(underSpec + "/" + under12);
			double pts = build.CalcScore(Cur, null, (str, i) => { li.SubItems.Add(str); });
			m.score = pts;

			// put the sum points into the first item
			li.SubItems[0].Text = pts.ToString("0.##");

			li.Tag = m;
			if (Program.Settings.TestGray && m.Current.Runes.Any(r => r.Locked))
				li.ForeColor = Color.Gray;
			else
			{
				if (m.Current.Sets.Any(rs => RuneProperties.MagicalSets.Contains(rs) && Rune.SetRequired(rs) == 2) &&
					m.Current.Sets.Any(rs => RuneProperties.MagicalSets.Contains(rs) && Rune.SetRequired(rs) == 4))
				{
					li.ForeColor = Color.Green;
				}
				else if (m.Current.Sets.Any(rs => RuneProperties.MagicalSets.Contains(rs) && Rune.SetRequired(rs) == 2))
				{
					li.ForeColor = Color.Goldenrod;
				}
				else if (m.Current.Sets.Any(rs => RuneProperties.MagicalSets.Contains(rs) && Rune.SetRequired(rs) == 4))
				{
					li.ForeColor = Color.DarkBlue;
				}
			}
			return li;
		}

		void textBox_TextChanged(object sender, EventArgs e)
		{
			// if we are generating builds, don't recalculate all the builds
			if (building) return;

			// TODO: try to only mangle the column which is changing?

			foreach (string stat in Build.statNames)
			{
				TextBox tb = (TextBox)Controls.Find(stat + "Worth", true).FirstOrDefault();
				double val;
				double.TryParse(tb?.Text, out val);
				build.Sort[stat] = val;
			}
			foreach (string extra in Build.extraNames)
			{
				TextBox tb = (TextBox)Controls.Find(extra + "Worth", true).FirstOrDefault();
				double val;
				double.TryParse(tb?.Text, out val);
				build.Sort.ExtraSet(extra, val);
			}
			// "sort" as in, recalculate the whole number
			foreach (ListViewItem li in loadoutList.Items)
			{
				ListItemSort(li);
			}
			var lv = loadoutList;
			var lvs = (ListViewSort)(lv).ListViewItemSorter;
			lvs.OnColumnClick(0, false, true);
			// actually sort the list, on points
			lv.Sort();
		}

		// recalculate all the points for this monster
		// TODO: consider hiding point values in the subitem tags and only recalcing the changed column
		// TODO: pull the scoring algorithm into a neater function
		public void ListItemSort(ListViewItem li)
		{
			Monster load = (Monster)li.Tag;
			var Cur = load.GetStats();

			double pts = build.CalcScore(Cur, null, (str, num) => { li.SubItems[num].Text = str; });
			
			li.SubItems[0].Text = pts.ToString("0.##");

		}

		private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (building) return;

			var sorter = (ListViewSort)((ListView)sender).ListViewItemSorter;
			sorter.OnColumnClick(e.Column, false, true);
			((ListView)sender).Sort();
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			// Things went okay
			DialogResult = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// things were :(
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			if (loadoutList.SelectedItems.Count > 0)
			{
				ListViewItem lit = loadoutList.Items[0];
				ListViewItem lis = loadoutList.SelectedItems[0];

				if (lit == lis)
					return;

				Monster mY = (Monster)lis.Tag;
				Monster mN = (Monster)lit.Tag;

				List<Attr> better = new List<Attr>();

				building = true;

				foreach (Attr stat in Build.statAll)
				{
					if (!stat.HasFlag(Attr.ExtraStat) && mY.GetStats()[stat] > mN.GetStats()[stat])
						better.Add(stat);
				}
				double totalsort = 0;
				foreach (var stat in Build.statAll)
				{
					if (!stat.HasFlag(Attr.ExtraStat) && build.Sort[stat] != 0)
						totalsort += Math.Abs(build.Sort[stat]);
				
					if (stat.HasFlag(Attr.ExtraStat) && build.Sort.ExtraGet(stat) != 0)
						totalsort += Math.Abs(build.Sort.ExtraGet(stat));
				}
				if (totalsort == 0)
				{
					double totalstats = 0;
					foreach (var stat in better)
					{
						if (!stat.HasFlag(Attr.ExtraStat))
							totalstats += mY.GetStats()[stat];
						else
							totalstats += mY.GetStats().ExtraValue(stat);
					}
					int amount = (int)Math.Max(30, Math.Sqrt(Math.Max(100, totalstats)));
					foreach (var stat in better)
					{
						if (!stat.HasFlag(Attr.ExtraStat))
						{
							build.Sort[stat] = (int)(amount * (mY.GetStats()[stat] / totalstats));
							TextBox tb = (TextBox)Controls.Find(stat + "Worth", true).FirstOrDefault();
							if (tb != null)
								tb.Text = build.Sort[stat].ToString(System.Globalization.CultureInfo.CurrentUICulture);
						}
						else
						{
							build.Sort.ExtraSet(stat, (int)(amount * (mY.GetStats().ExtraValue(stat) / totalstats)));
							TextBox tb = (TextBox)Controls.Find(stat + "Worth", true).FirstOrDefault();
							if (tb != null)
								tb.Text = build.Sort.ExtraGet(stat).ToString(System.Globalization.CultureInfo.CurrentUICulture);
						}
					}
				}
				else
				{
					// todo
				}

				building = false;
				textBox_TextChanged(null, null);
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			if (Main.help != null)
				Main.help.Close();

			Main.help = new Help();
			Main.help.url = Environment.CurrentDirectory + "\\User Manual\\test.html";
			Main.help.Show();
		}

		private void runeDial_RuneClick(object sender, RuneClickEventArgs e)
		{
			if (e.Rune == null)
			{
				runeBox.Hide();
			}
			else
			{
				runeBox.Show();
				runeBox.SetRune(e.Rune);
			}
		}
		
		private void runeBox_hidden(object sender, EventArgs e)
		{
			runeDial.ResetRuneClicked();
		}

		private void loadoutList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loadoutList.FocusedItem != null)
			{
				var item = loadoutList.FocusedItem;
				if (item.Tag != null)
				{
					Monster mon = (Monster)item.Tag;
					runeDial.Loadout = mon.Current;
				}
			}
		}
		
		private void btn_powerrunes_Click(object sender, EventArgs e)
		{
			if (!building)
			{
				using (var qq = new RuneSelect())
				{
					qq.runes = build.GetPowerupRunes();
					qq.sortFunc = r => -(int)r.manageStats.GetOrAdd("besttestscore", 0);
					qq.runeStatKey = "besttestscore";
					qq.ShowDialog();
				}
			}
		}

		private void Generate_FormClosing(object sender, FormClosingEventArgs e)
		{
			build.loads.CollectionChanged -= Loads_CollectionChanged;
			build.BuildPrintTo -= Build_BuildPrintTo;
			build.BuildProgTo -= Build_BuildProgTo;
		}

		private void btn_runtest_Click(object sender, EventArgs e)
		{
			this.toolStripStatusLabel1.Text = "Generating...";
			try
			{
				if (build.IsRunning)
					build.Cancel();
				else
				{
					Program.RunTest(build, (b, res) =>
					{
						if (b.loads == null)
						{
							toolStripStatusLabel1.Text = "Error: " + res;
							return;
						}

						if (!IsDisposed && IsHandleCreated)
						{
							Invoke((MethodInvoker)delegate
							{
								toolStripStatusLabel1.Text = "Generated " + loadoutList.Items.Count + " builds";
								building = false;
							});
						}
					});
				}
			}
			catch (Exception ex)
			{
				Program.log.Error("Error running tests: " + ex.GetType() + ": " + ex.Message);
				MessageBox.Show("Error running tests: " + ex.GetType() + ": " + ex.Message);
			}
		}

	}
}
