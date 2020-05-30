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
	public class MakeSoundBar :Component
	{
		private string m_TargetDir = "";
		public string TargetDir {  get { return m_TargetDir; } }

		private string m_exportFileName = "";
		public string ExportFileName { get { return m_exportFileName; } }


		private double [][] m_SoundData  =  new double[0][];

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
		public MakeSoundBar()
		{

		}
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

			int cnt = files.Length;
			if ( cnt<= 0) return ret;
			//配列の初期化
			double[][] v = new double[m_LevelCount][];
			double[][] v2 = new double[m_LevelCount][];
			for(int i=0; i<m_LevelCount; i++)
			{
				v[i] = new double[cnt];
				v2[i] = new double[cnt];
				for (int j=0;j<cnt;j++)
				{
					v[i][j] = 0;
					v2[i][j] = 0;
				}
			}

			if (m_ProgressBar != null)
			{
				m_ProgressBar.Minimum = 0;
				m_ProgressBar.Maximum = cnt;
				m_ProgressBar.Value = 0;
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
			}
			//平坦化する
			for (int i=0; i<m_LevelCount;i++)
			{
				v2[i][0] = v[i][0];
				v2[i][cnt-1] = v[i][cnt-1];
				for (int j=1; j<cnt-1;j++)
				{
					v2[i][j] = (v[i][j - 1] + v[i][j + 1]) / 2;
				}

			}

			m_SoundData = v2;
			ret = true;
			return ret;
		}


		public bool SetDir(string p)
		{
			bool ret = false;
			m_TargetDir = "";
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


	}
}
