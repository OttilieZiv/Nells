using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CrystalDecisions.Windows.Forms;

namespace NailSalon
{
    /// <summary>
    /// Interaction logic for ReportViewer.xaml
    /// </summary>
    public partial class ReportViewer : Window
    {
        CrystalReportViewer _view = new CrystalReportViewer();

        public ReportViewer()
        {
            InitializeComponent();
            _view.ToolPanelView = ToolPanelViewType.None;
            _view.ShowGroupTreeButton = false;
            whRep.Child = _view;
        }

        private void btnBrandAnalysis_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.RPT_BrandCountTableAdapter ta = new dsReportsTableAdapters.RPT_BrandCountTableAdapter();
            dsReportsTableAdapters.QueriesTableAdapter taQ = new dsReportsTableAdapters.QueriesTableAdapter();
            BrandAnalysis rep = new BrandAnalysis();
            int UnusedBrandCount = (int)taQ.RPT_UnusedBrands();
            int FullyUsedBrandCount = (int)taQ.RPT_FullyUsedBrands();
            int TotalBrandCount = (int)taQ.RPT_TotalBrandCount();

            ta.Fill(data.RPT_BrandCount);
            rep.SetDataSource(data);
            rep.SetParameterValue("TotalBrandCount", TotalBrandCount);
            rep.SetParameterValue("UnusedBrandCount", UnusedBrandCount);
            rep.SetParameterValue("FullyUsedBrandCount", FullyUsedBrandCount);

            _view.ReportSource = rep;
            _view.Refresh();
        }

        private void btnColours_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.RPT_CountsTableAdapter ta = new dsReportsTableAdapters.RPT_CountsTableAdapter();
            ta.FillDrawerCount(data.RPT_Counts);

            GeneralAnalysis rep = new GeneralAnalysis();
            rep.SetDataSource(data);
            rep.SetParameterValue("Name", "Colour Drawer");

            _view.ReportSource = rep;
            _view.Refresh();
            //dsReports data = new dsReports();
            //dsReportsTableAdapters.RPT_DrawerCountTableAdapter ta = new dsReportsTableAdapters.RPT_DrawerCountTableAdapter();
            //ta.Fill(data.RPT_DrawerCount);

            //DrawerAnalysis rep = new DrawerAnalysis();
            //rep.SetDataSource(data);

            //_view.ReportSource = rep;
            //_view.Refresh();
        }

        private void btnBrandsAM_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.RPT_BrandCountTableAdapter ta = new dsReportsTableAdapters.RPT_BrandCountTableAdapter();
            dsReportsTableAdapters.QueriesTableAdapter taQ = new dsReportsTableAdapters.QueriesTableAdapter();
            BrandAnalysis rep = new BrandAnalysis();
            int UnusedBrandCount = (int)taQ.RPT_UnusedBrands();
            int FullyUsedBrandCount = (int)taQ.RPT_FullyUsedBrands();
            int TotalBrandCount = (int)taQ.RPT_TotalBrandCount();

            ta.FillSubset(data.RPT_BrandCount,"0","L");
            rep.SetDataSource(data);
            rep.SetParameterValue("TotalBrandCount", TotalBrandCount);
            rep.SetParameterValue("UnusedBrandCount", UnusedBrandCount);
            rep.SetParameterValue("FullyUsedBrandCount", FullyUsedBrandCount);

            _view.ReportSource = rep;
            _view.Refresh();
        }

        private void btnBrandsNZ_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.RPT_BrandCountTableAdapter ta = new dsReportsTableAdapters.RPT_BrandCountTableAdapter();
            dsReportsTableAdapters.QueriesTableAdapter taQ = new dsReportsTableAdapters.QueriesTableAdapter();
            BrandAnalysis rep = new BrandAnalysis();
            int UnusedBrandCount = (int)taQ.RPT_UnusedBrands();
            int FullyUsedBrandCount = (int)taQ.RPT_FullyUsedBrands();
            int TotalBrandCount = (int)taQ.RPT_TotalBrandCount();

            ta.FillSubset(data.RPT_BrandCount, "L", "ZZ");
            rep.SetDataSource(data);
            rep.SetParameterValue("TotalBrandCount", TotalBrandCount);
            rep.SetParameterValue("UnusedBrandCount", UnusedBrandCount);
            rep.SetParameterValue("FullyUsedBrandCount", FullyUsedBrandCount);

            _view.ReportSource = rep;
            _view.Refresh();
        }

        private void btnCountry_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.RPT_CountsTableAdapter ta = new dsReportsTableAdapters.RPT_CountsTableAdapter();
            ta.FillCountryCount(data.RPT_Counts);

            GeneralAnalysis rep = new GeneralAnalysis();
            rep.SetDataSource(data);
            rep.SetParameterValue("Name", "Country");

            _view.ReportSource = rep;
            _view.Refresh();
        }

        private void btnBrandType_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.RPT_CountsTableAdapter ta = new dsReportsTableAdapters.RPT_CountsTableAdapter();
            ta.FillBrandTypeCount(data.RPT_Counts);

            GeneralAnalysis rep = new GeneralAnalysis();
            rep.SetDataSource(data);
            rep.SetParameterValue("Name", "Brand Type");

            _view.ReportSource = rep;
            _view.Refresh();
        }

        private void btnBrandCountryProportions_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.SegmentsTableAdapter ta = new dsReportsTableAdapters.SegmentsTableAdapter();
            dsReportsTableAdapters.QueriesTableAdapter taQ = new dsReportsTableAdapters.QueriesTableAdapter();
            ta.FillBrandCountrySplit(data.Segments);
            int total = (int)taQ.RPT_TotalBrandCount();

            Segments rep = new Segments();
            rep.SetDataSource(data);
            rep.SetParameterValue("Title", "Brands per country");
            rep.SetParameterValue("SegmentName", "Country");
            rep.SetParameterValue("TotalCount", total);

            _view.ReportSource = rep;
            _view.Refresh();
        }

        private void btnBrandsPerType_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.SegmentsTableAdapter ta = new dsReportsTableAdapters.SegmentsTableAdapter();
            dsReportsTableAdapters.QueriesTableAdapter taQ = new dsReportsTableAdapters.QueriesTableAdapter();
            ta.FillBrandTypeSplit(data.Segments);
            int total = (int)taQ.RPT_TotalBrandCount();

            Segments rep = new Segments();
            rep.SetDataSource(data);
            rep.SetParameterValue("Title", "Brands per type");
            rep.SetParameterValue("SegmentName", "Type");
            rep.SetParameterValue("TotalCount", total);

            _view.ReportSource = rep;
            _view.Refresh();
        }

        private void btnBottlesPerCountry_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.SegmentsTableAdapter ta = new dsReportsTableAdapters.SegmentsTableAdapter();
            dsReportsTableAdapters.QueriesTableAdapter taQ = new dsReportsTableAdapters.QueriesTableAdapter();
            ta.FillBottleCountrySplit(data.Segments);
            int total = (int)taQ.RPT_TotalBottleCount();

            Segments rep = new Segments();
            rep.SetDataSource(data);
            rep.SetParameterValue("Title", "Bottles per country");
            rep.SetParameterValue("SegmentName", "Country");
            rep.SetParameterValue("TotalCount", total);

            _view.ReportSource = rep;
            _view.Refresh();
        }

        private void btnBottlesPerType_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.SegmentsTableAdapter ta = new dsReportsTableAdapters.SegmentsTableAdapter();
            dsReportsTableAdapters.QueriesTableAdapter taQ = new dsReportsTableAdapters.QueriesTableAdapter();
            ta.FillBottleTypeSplit(data.Segments);
            int total = (int)taQ.RPT_TotalBottleCount();

            Segments rep = new Segments();
            rep.SetDataSource(data);
            rep.SetParameterValue("Title", "Bottles per type");
            rep.SetParameterValue("SegmentName", "Type");
            rep.SetParameterValue("TotalCount", total);

            _view.ReportSource = rep;
            _view.Refresh();
        }

        private void btnBottlesPerBrand_Click(object sender, RoutedEventArgs e)
        {
            dsReports data = new dsReports();
            dsReportsTableAdapters.SegmentsTableAdapter ta = new dsReportsTableAdapters.SegmentsTableAdapter();
            dsReportsTableAdapters.QueriesTableAdapter taQ = new dsReportsTableAdapters.QueriesTableAdapter();
            ta.FillBrandBottleSplit(data.Segments);
            int total = (int)taQ.RPT_TotalBottleCount();

            Segments rep = new Segments();
            rep.SetDataSource(data);
            rep.SetParameterValue("Title", "Bottles per brand");
            rep.SetParameterValue("SegmentName", "Brand");
            rep.SetParameterValue("TotalCount", total);

            _view.ReportSource = rep;
            _view.Refresh();
        }
    }
}
