using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Codeplex.Data;

namespace SoundBars
{
	public class MakeSoundBar :Control
	{
		private double [][] m_SoundData  =  new double[0][];
		private double [][] m_SoundDataBak  =  new double[0][];
		private int m_FrameCount = 0;
		private int m_Position = 0;
		private int m_BarWidth = 0;
		private int m_BarHeight = 0;
		private int[] m_LeftTable = new int[0];
		private int m_Top = 10;
		private System.Windows.Forms.Timer m_Timer = new System.Windows.Forms.Timer();
		private bool anime = false;
		// ****************************************************************************
		private void SizeChk()
		{
			int w = this.Width / (m_LevelCount*2 + 2);
			int h = this.Height - m_Top*2;
			m_BarWidth = w;
			m_BarHeight = h;
			m_LeftTable = new int[m_LevelCount];
			for (int i = 0; i < m_LevelCount; i++) m_LeftTable[i] = 2 * w * (i + 1);
			if (m_SoundData.Length > 0)
			{
				m_FrameCount = m_SoundData[0].Length;
			}
			else
			{
				m_FrameCount = 0;
			}
			if(m_Position>=m_FrameCount)
			{
				m_Position = 0;
			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			SizeChk();
		}
		// ****************************************************************************
		#region Property
		private string m_TargetDir = "";
		public string TargetDir {  get { return m_TargetDir; } }

		private string m_exportFileName = "";
		public string ExportFileName { get { return m_exportFileName; } }



		private int m_LevelCount = 18;
		public int LevelCount
		{
			get { return m_LevelCount; }
			set
			{
				if (m_LevelCount != value)
				{
					m_LevelCount = value;
					if(m_NumLavelCount!=null)
					{
						if(m_NumLavelCount.Value !=(decimal)value)
						{
							m_NumLavelCount.Value = (decimal)value;
						}
					}
				}
			}
		}
		private int m_LevelMax = 255;
		public int LevelMax
		{
			get { return m_LevelMax; }
			set
			{
				if (m_LevelMax != value)
				{
					m_LevelMax = value;
					if(m_NumLavelMax!=null)
					{
						if(m_NumLavelMax.Value !=(decimal)value)
						{
							m_NumLavelMax.Value = (decimal)value;
						}
					}
				}
			}
		}

		private NumericUpDown m_NumLavelCount = null;
		public NumericUpDown NumLavelCount
		{
			get { return m_NumLavelCount; }
			set
			{
				m_NumLavelCount = value;
				if (m_NumLavelCount != null)
				{
					m_NumLavelCount.ValueChanged += M_NumLavelCount_ValueChanged;
				}
			}
		}

		private void M_NumLavelCount_ValueChanged(object sender, EventArgs e)
		{
			if (m_NumLavelCount == null) return;
			if (m_LevelCount != (int)m_NumLavelCount.Value)
			{
				m_LevelCount = (int)m_NumLavelCount.Value;
			}
		}
		private NumericUpDown m_NumLavelMax = null;
		public NumericUpDown NumLavelMax
		{
			get { return m_NumLavelMax; }
			set
			{
				m_NumLavelMax = value;
				if (m_NumLavelMax != null)
				{
					m_NumLavelMax.ValueChanged += M_NumLavelMax_ValueChanged;
				}
			}
		}

		private void M_NumLavelMax_ValueChanged(object sender, EventArgs e)
		{
			if (m_NumLavelMax == null) return;
			if (m_LevelMax != (int)m_NumLavelMax.Value)
			{
				m_LevelMax = (int)m_NumLavelMax.Value;
			}
		}

		private ProgressBar m_ProgressBar = null;
		public ProgressBar ProgressBar
		{
			get { return m_ProgressBar; }
			set
			{
				m_ProgressBar = value;
			}
		}

		private TrackBar m_TrackBar = null;
		public TrackBar TrackBar
		{
			get { return m_TrackBar; }
			set
			{
				m_TrackBar = value;
				if(m_TrackBar != null)
				{
					m_TrackBar.Minimum = 0;
					m_TrackBar.Maximum = m_FrameCount;
					if (m_TrackBar.Value != m_Position)m_TrackBar.Value = m_Position;

					m_TrackBar.ValueChanged += M_TrackBar_ValueChanged;

				}

			}
		}

		private void M_TrackBar_ValueChanged(object sender, EventArgs e)
		{
			if( m_Position != m_TrackBar.Value)
			{
				m_Position = m_TrackBar.Value;
				this.Invalidate();
			}
		}
		private Button m_PlayBtn = null;
		public Button PlayBtn
		{
			get { return m_PlayBtn; }
			set
			{
				m_PlayBtn = value;
				if(m_PlayBtn != null)
				{
					m_PlayBtn.Click += M_PlayBtn_Click;
					m_PlayBtn.Text = "Start";
				}
			}
		}

		private void M_PlayBtn_Click(object sender, EventArgs e)
		{
			StartStop();
		}
		#endregion
		// ****************************************************************************
		public MakeSoundBar()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			this.Size = new Size(200, 100);

			m_Timer.Interval = 1000 / 24;
			m_Timer.Tick += M_Timer_Tick;

		}
		public void Start()
		{
			if (m_FrameCount > 0)
			{
				anime = true;
				m_Timer.Start();
				if (m_PlayBtn != null)
				{
					m_PlayBtn.Text = "Stop";
				}
			}
			else
			{
				anime = false;
				m_Timer.Stop();
				if (m_PlayBtn != null)
				{
					m_PlayBtn.Text = "Start";
				}

			}
		}
		public void Stop()
		{
			anime = false;
			m_Timer.Stop();
			if (m_PlayBtn != null)
			{
				m_PlayBtn.Text = "Start";
			}
		}
		public void StartStop()
		{
			if (anime)
			{
				Stop();
			}
			else
			{
				Start();
			}
		}
		private void M_Timer_Tick(object sender, EventArgs e)
		{
			if (m_FrameCount <= 0)
			{
				Stop();
			}
			if (anime)
			{
				this.Invalidate();
				this.Update();
				m_Position = (m_Position + 1) % m_FrameCount;
				if (m_TrackBar != null)
				{
					m_TrackBar.Value = m_Position;
				}
			}
		}

		// ****************************************************************************
		private double[] dataFromPictureFile(string p)
		{
			double[] ret = new double[m_LevelCount];
			for (int i = 0; i < ret.Length; i++) ret[i] = 0;

			if (File.Exists(p) == false) return new double[0];

			using (Bitmap img = new Bitmap(Image.FromFile(p)))
			{
				BitmapPlus bmpP = new BitmapPlus(img);
				try
				{
					bmpP.BeginAccess();

					for (int y = 0; y < m_LevelCount; y++)
					{
						int v = bmpP.LineValue(y);
						if (v < 0)
						{
							return new double[0];
						}
						ret[y] = (double)v / (double)m_LevelMax;
					}
				}
				finally {
					bmpP.EndAccess();
				}
			}
			return ret;
		}
		private string[] GetFiles(string p)
		{
			string [] ret = new string[0];

			//ファイルだったら親ディレクトリを
			if (File.Exists(p) == true)
			{
				p = Path.GetDirectoryName(p);
			}

			//フォルダじゃなかったらNG
			if(Directory.Exists(p) == false)
			{
				return ret;
			}
			IEnumerable<string> files = Directory.EnumerateFiles(p, "*.png",SearchOption.TopDirectoryOnly);

			int cnt = files.Count<string>();

			if (cnt <= 0) return ret;

			ret = new string[cnt];

			int idx = 0;
			foreach (string file in files) {
				ret[idx] = file;
				idx++;
			}
			m_TargetDir = p;
			return ret;
		}

		private bool Analysis(string[] files)
		{
			bool ret = false;
			m_SoundData = new double[0][];
			m_SoundDataBak = new double[0][];
			m_FrameCount = 0;

			int cnt = files.Length;
			if ( cnt<= 0) return ret;
			//配列の初期化
			double[][] v = new double[m_LevelCount][];
			for(int i=0; i<m_LevelCount; i++)
			{
				v[i] = new double[cnt];
				for (int j=0;j<cnt;j++)
				{
					v[i][j] = 0;
				}
			}

			if (m_ProgressBar != null)
			{
				m_ProgressBar.Minimum = 0;
				m_ProgressBar.Maximum = cnt;
				m_ProgressBar.Value = 0;
				m_ProgressBar.Visible = true;
			}
			for (int i=0; i<cnt;i++)
			{
				if (m_ProgressBar != null)
				{
					m_ProgressBar.Value = i;
					m_ProgressBar.Update();
				}
				double[] vv = dataFromPictureFile(files[i]);
				if (vv.Length != m_LevelCount)
				{
					return ret;
				}
				for ( int j=0; j<m_LevelCount;j++)
				{
					v[j][i] = vv[j];
				}
			}
			if (m_ProgressBar != null)
			{
				m_ProgressBar.Minimum = 0;
				m_ProgressBar.Maximum = cnt;
				m_ProgressBar.Value = 0;
				m_ProgressBar.Visible = false;
			}

			m_SoundData = v;
			SizeChk();
			ToCopy(m_SoundData, ref m_SoundDataBak);

			if (m_TrackBar!=null)
			{
				m_TrackBar.Maximum = m_FrameCount;
			}
			Start();
			ret = true;
			return ret;
		}
		private void ToCopy(double[][] src, ref double[][] dst)
		{
			int c = src.Length;
			dst = new double[c][];
			if(c>0)
			{
				int l = src[0].Length;
				if (l > 0)
				{
					for (int i = 0; i < c; i++)
					{
						dst[i] = new double[l];
						for (int j = 0; j < l; j++)
						{
							dst[i][j] = src[i][j];
						}
					}
				}
			}
		}

		public bool SetDir(string p)
		{
			bool ret = false;
			m_TargetDir = "";
			if (anime)
			{
				Stop();
			}
			string[] files = GetFiles(p);
			if (files.Length <= 0) return ret;

			if (Analysis(files) == false)
			{
				return ret;
			}
			m_TargetDir = p;
			ret = true;
			return ret;
		}
		public string ToJson()
		{
			dynamic data = new DynamicJson();
			int LC = 0;
			int FC = 0;
			if(m_SoundData.Length>=0)
			{
				LC = m_SoundData.Length;
				FC = m_SoundData[0].Length;
			}
			data["LevelCount"] = LC;
			data["FrameCount"] = FC;
			data["data"] = m_SoundData;

			return data.ToString();
		}

		public void SelectFileDlg()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "画像ファイルを選んでください";
			dlg.Filter = "*.png|*.png";
			if (m_TargetDir == "")
			{
				dlg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			}
			else
			{
				dlg.InitialDirectory = m_TargetDir;
			}
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				SetDir(Path.GetDirectoryName(dlg.FileName));
			}
		}
		public bool ExportFileDlg()
		{
			bool ret = false;
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "出力ファイルを指定してください。";
			dlg.Filter = "*.json|*.json|*.*|*.*";
			dlg.DefaultExt = "json";
			if (m_exportFileName == "")
			{
				if( m_TargetDir != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(m_TargetDir);
					dlg.FileName = Path.GetFileNameWithoutExtension(m_TargetDir) + ".json";
				}
				else
				{
					dlg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
					dlg.FileName = "sound.json";

				}
			}
			else
			{
				dlg.InitialDirectory = Path.GetDirectoryName(m_exportFileName);
				dlg.FileName = Path.GetFileNameWithoutExtension(m_exportFileName) + ".json";
			}
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				ret = SaveFile(dlg.FileName);
			}
			return ret;
		}
		public bool SaveFile(string p)
		{
			bool ret = false;
			if(p=="")
			{
				return ExportFileDlg();
			}
			StreamWriter sw = new System.IO.StreamWriter(p);
			try
			{
				sw.Write(ToJson());
				ret = true;

			}
			catch
			{
				ret = false;
			}
			finally
			{
				sw.Close();

			}
			return ret;
		}
		// ****************************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			SolidBrush sb = new SolidBrush(Color.Black);
			try
			{
				g.FillRectangle(sb, this.ClientRectangle);
				sb.Color = Color.White;
				g.DrawString(String.Format("{0}", m_Position), this.Font, sb, 5, 5);
				if (m_FrameCount > 0)
				{
					if (m_LevelCount > 0)
					{
						for (int i=0; i<m_LevelCount;i++)
						{
							int h = (int)((double)m_BarHeight * m_SoundData[i][m_Position]);
							int t = this.Height - m_Top - h;
							Rectangle r = new Rectangle(m_LeftTable[i], t, m_BarWidth, h);
							g.FillRectangle(sb, r);
						}

					}
				}
			}
			finally
			{
				sb.Dispose();
			}
		}
		// ****************************************************************************
		public void Flat2()
		{
			if ((m_FrameCount <= 0) || (m_LevelCount <= 0)) return;

			int cnt = m_FrameCount / 2;
			bool b = anime;
			if (anime) Stop();

			double[][] Bak = new double[0][];
			ToCopy(m_SoundData, ref Bak);

			for (int lc = 0; lc < m_LevelCount; lc++)
			{
				for (int i = 0; i < cnt; i++)
				{
					int v0 = i * 2;
					int v1 = v0 + 1;
					int v2 = v0 + 2;
					if (v2 >= m_FrameCount) break;

					m_SoundData[lc][v1] = (Bak[lc][v0] + Bak[lc][v2]) / 2;
				}
			}

			if (b) Start();
		}// ****************************************************************************
		public void Flat3()
		{
			if ((m_FrameCount <= 0) || (m_LevelCount <= 0)) return;

			int cnt = m_FrameCount / 3;
			bool b = anime;
			if (anime) Stop();

			double[][] Bak = new double[0][];
			ToCopy(m_SoundData, ref Bak);

			for (int lc = 0; lc < m_LevelCount; lc++)
			{
				for (int i = 0; i < cnt; i++)
				{
					int v0 = i * 3;
					int v1 = v0 + 1;
					int v2 = v0 + 2;
					int v3 = v0 + 3;
					if (v1 >= m_FrameCount) break;
					if (v2 >= m_FrameCount) break;
					if (v3 >= m_FrameCount) break;

					m_SoundData[lc][v1] = (Bak[lc][v0]*2/3 + Bak[lc][v3]*1/3) ;
					m_SoundData[lc][v2] = (Bak[lc][v0]*1/3 + Bak[lc][v3]*2/3) ;
				}
			}

			if (b) Start();
		}
		public void Org()
		{
			if ((m_FrameCount <= 0) || (m_LevelCount <= 0)) return;
			bool b = anime;
			if (anime) Stop();

			ToCopy(m_SoundDataBak, ref m_SoundData);

			if (b) Start();
		}
	}
}
