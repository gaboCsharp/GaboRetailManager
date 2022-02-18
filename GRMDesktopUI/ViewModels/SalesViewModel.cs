using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _product;

        public BindingList<string> Product
        {
            get { return _product; }
            set 
            { 
                _product = value; 
                NotifyOfPropertyChange(() => Product);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public bool CanAddtoCart
        {
            get
            {
                bool output = false;
                //Make sure something is selected
      
               

                return output;

            }
        }

        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

      

        public string SubTotal
        { 
            get 
            { 
                return "$0.00"; 
            }            
        }

        public string Tax
        {
            get
            {
                return "$0.00";
            }
        }

        public string Total
        {
            get
            {
                return "$0.00";
            }
        }


        public void AddtoCart()
        {

        }

        public void RemoveFromCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;
                //Make sure there is something in the cart



                return output;

            }
        }

        public void CheckOut()
        {
            
        }




    }
}
