using System;
using System.Collections.Generic;
using CivopApp.Domain;
using CivopApp.Presenters;
using CivopApp.Views;

namespace CivopApp
{
    public partial class OrderPage : BasePage, IOrderView
    {
        private readonly OrderPresenter _presenter;
        private const string REDIRECT_URL = "~/Orders";

        public OrderPage()
        {
            _presenter = new OrderPresenter(this, DbContext);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.OnLoadPage();
            dropdownProduct.DataSource = AllProducts;
            dropdownProduct.DataBind();
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            _presenter.SaveOrder();
            Response.Redirect(REDIRECT_URL);
        }

        protected void btnAddProduct_OnClick(object sender, EventArgs e)
        {
            _presenter.SaveOrder();
        }

        protected void btnSubmit_Delete(object sender, EventArgs e)
        {
            _presenter.DeleteOrder();
            Response.Redirect(REDIRECT_URL);
        }

        /// <inheritdoc />
        public string CustomerName
        {
            get => txtCustomerName.Text;
            set => txtCustomerName.Text = value;
        }

        /// <inheritdoc />
        public string CustomerPostAddress
        {
            get => txtCustomerPostAddress.Text;
            set => txtCustomerPostAddress.Text = value;
        }

        /// <inheritdoc />
        public int? OrderId
        {
            get
            {
                if (int.TryParse(hdnOrderId.Value, out var id))
                    return id;
                return
                    null;
            }
            set => hdnOrderId.Value = value.ToString();
        }

        /// <inheritdoc />
        public int? ProductId
        {
            get
            {
                if (int.TryParse(dropdownProduct.SelectedValue, out var id))
                    return id;
                return null;
            }
            set
            {
                dropdownProduct.SelectedValue = value.ToString();
            }
        }

        /// <inheritdoc />
        public float Quantity
        {
            get
            {
                if (float.TryParse(txtProductQty.Text, out var qty))
                    return qty;
                return 0;
            }
            set => txtProductQty.Text = value.ToString();
        }

        /// <inheritdoc />
        public IList<OrderProduct> Products { get; set; }

        /// <inheritdoc />
        public IList<Product> AllProducts { get; set; }

     
    }
}