using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomobileWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICarRepository carRepository;
        public MainWindow()
        {
            InitializeComponent();
            carRepository= new CarRepository();
        }

        private Car getCarObject()
        {
            Car car = null;
            try
            {
                car = new Car { CarId = int.Parse(txtCarId.Text), CarName = txtCarName.Text, Manufacturer = txtManufacturer.Text, Price = decimal.Parse(txtPrice.Text), ReleasedYear = int.Parse(txtReleaseYear.Text) };
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return car;
        }

        public void LoadCarList()
        {
            lvCars.ItemsSource = carRepository.GetCars();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCarList();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Load Car List");
            }
        }

        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = getCarObject();
                carRepository.InsertCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} insert successfully", "Inser car");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = getCarObject();
                carRepository.UpdateCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} update successfully", "Update car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = getCarObject();
                carRepository.DeleteCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} deleted successfully", "Update car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
