using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KB13177_WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ultraGrid1.DataSource = GetData();
        }

        private DataTable GetData()
        {
            var dt = new DataTable();

            var idColumn = dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Author", typeof(String));
            dt.Columns.Add("Title", typeof(String));
            dt.Columns.Add("Excerpt", typeof(String));

            dt.Rows.Add(new object[] { 1, "清少納言", "枕草子", "春はあけぼの。" });
            dt.Rows.Add(new object[] { 2, "鴨長明", "方丈記", "行く川のながれは絶えずして、しかも本の水にあらず。" });
            dt.Rows.Add(new object[] { 3, "吉田兼好", "徒然草", "つれづれなるまゝに、日暮らし、硯に向ひて、心に移り行くよしなしごとを、そこはかとなく書きつくれば、怪しうこそ物狂ほしけれ。" });

            dt.PrimaryKey = new DataColumn[] { idColumn };

            return dt;
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // 行の高さが中身に合わせて自動調整されるように、DisplayLayout の Override の RowSizing に AutoFixed を設定する。
            // ※この設定をしないと、テキストは折り返されて表示されるものの、行に1行分の高さしか割り当てられず、
            // ※非常に見にくい結果になってしまいます。
            e.Layout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;

            e.Layout.Bands[0].Columns["Excerpt"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
        }
    }
}
