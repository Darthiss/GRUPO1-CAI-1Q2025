using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{   
    public class ItemCarrito : INotifyPropertyChanged

    {
        private Producto _producto;

        private int _cantidad;

        public Producto Producto
        {
            get => _producto;
            set
            {
                if (_producto != value)

                {
                    _producto = value;

                    OnPropertyChanged(nameof(Producto));

                    OnPropertyChanged(nameof(Subtotal));

                    OnPropertyChanged(nameof(ToString));

                }

            }

        }

        public int Cantidad

        {
            get => _cantidad;

            set

            {

                if (_cantidad != value)

                {

                    _cantidad = value;

                    OnPropertyChanged(nameof(Cantidad));

                    OnPropertyChanged(nameof(Subtotal));

                    OnPropertyChanged(nameof(ToString));

                }

            }

        }

        public decimal Subtotal => Producto?.Precio * Cantidad ?? 0;

        public ItemCarrito(Producto producto, int cantidad)

        {

            Producto = producto;

            Cantidad = cantidad;

        }

        public override string ToString()

        {

            return $"{Producto.Nombre} - {Cantidad} - ${Subtotal}";

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }



}

