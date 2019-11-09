using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace MyWpfLinq
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region INotify Changed Properties  
        private string message;
        public string Message
        {
            get { return message; }
            set { SetField(ref message, value, nameof(Message)); }
        }

        private ObservableCollection<string> setA;
        public ObservableCollection<string> SetA
        {
            get { return setA; }
            set { SetField(ref setA, value, nameof(SetA)); }
        }

        private ObservableCollection<string> setB;
        public ObservableCollection<string> SetB
        {
            get { return setB; }
            set { SetField(ref setB, value, nameof(SetB)); }
        }

        private ObservableCollection<string> setT;
        public ObservableCollection<string> SetT
        {
            get { return setT; }
            set { SetField(ref setT, value, nameof(SetT)); }
        }

        private ObservableCollection<string> intersectionAB;
        public ObservableCollection<string> IntersectionAB
        {
            get { return intersectionAB; }
            set { SetField(ref intersectionAB, value, nameof(IntersectionAB)); }
        }

        private ObservableCollection<string> unionAB;
        public ObservableCollection<string> UnionAB
        {
            get { return unionAB; }
            set { SetField(ref unionAB, value, nameof(UnionAB)); }
        }

        private ObservableCollection<string> relativeComplementAB;
        public ObservableCollection<string> RelativeComplementAB
        {
            get { return relativeComplementAB; }
            set { SetField(ref relativeComplementAB, value, nameof(RelativeComplementAB)); }
        }

        private bool subsetIndicatorT;
        public bool SubsetIndicatorT
        {
            get { return subsetIndicatorT; }
            set { SetField(ref subsetIndicatorT, value, nameof(SubsetIndicatorT)); }
        }

        private string input;
        public string Input
        {
            get { return input; }
            set { SetField(ref input, value, nameof(Input)); }
        }

        // Template for a new INotify Changed Property
        // for using CTRL-R-R
        private ObservableCollection<string> xxx;
        public ObservableCollection<string> Xxx
        {
            get { return xxx; }
            set { SetField(ref xxx, value, nameof(Xxx)); }
        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            InitSets();
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// Button1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SetA.Add(Input);
        }

        /// <summary>
        /// Button2_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            SetB.Add(Input);
        }

        /// <summary>
        /// Button3_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            SetT.Add(Input);
        }

        /// <summary>
        /// Button4_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            // check and indicate if T is subset of A
            SubsetIndicatorT = SetT.All(x => SetA.Contains(x)); if(SubsetIndicatorT) Console.Beep(); else { Console.Beep(); Console.Beep(); }

            // execute the LINQ commands
            IntersectionAB = new ObservableCollection<string>(SetA.Intersect(SetB));
            UnionAB = new ObservableCollection<string>(SetA.Union(SetB));
            RelativeComplementAB = new ObservableCollection<string>(SetA.Except(SetB));
        }

        /// <summary>
        /// Button5_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            SetA.Clear();
            SetB.Clear();
            SetT.Clear();
            IntersectionAB.Clear();
            UnionAB.Clear();
            RelativeComplementAB.Clear();
        }

        /// <summary>
        /// Button6_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            InitSets();
        }

        /// <summary>
        /// Button_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
        /******************************/
        /*      Menu Events          */
        /******************************/
        #region Menu Events

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// InitSets
        /// </summary>
        private void InitSets()
        {
            SetA = new ObservableCollection<string>();
            SetB = new ObservableCollection<string>();
            SetT = new ObservableCollection<string>();
            IntersectionAB = new ObservableCollection<string>();
            UnionAB = new ObservableCollection<string>();
            RelativeComplementAB = new ObservableCollection<string>();

            SetA.Add("1");
            SetA.Add("2");
            SetA.Add("3");
            SetA.Add("4");
            SetA.Add("5");
            SetA.Add("6");
            SetA.Add("7");

            SetB.Add("4");
            SetB.Add("6");
            SetB.Add("8");
            SetB.Add("10");
            SetB.Add("11");

            SetT.Add("1");
            SetT.Add("2");
            SetT.Add("3");

            Input = "9";

            SubsetIndicatorT = false;
        }

        /// <summary>
        /// SetField
        /// for INotify Changed Properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        private void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        #endregion
    }
}

