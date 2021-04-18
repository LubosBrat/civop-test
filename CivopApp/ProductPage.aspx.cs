using System;
using CivopApp.Domain;
using CivopApp.Presenters;
using CivopApp.Views;

namespace CivopApp
{
    /// <summary>
    /// <inheritdoc cref="IProductView"/>
    /// </summary>
    public partial class ProductPage : BasePage, IProductView
    {
        private readonly ProductPresenter _presenter;

        public ProductPage()
        {
            _presenter = new ProductPresenter(this, DbContext);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var productId = Request.QueryString["productId"];
            _presenter.LoadProduct(productId);
            _presenter.OnLoadPage();
        }

        /// <summary>
        /// Editovaný produkt, je null, pokud jde o vytváření nového produktu
        /// </summary>
        public Product Product { get; set; }

        public string ProductName
        {
            get => txtName.Text;
            set => txtName.Text = value; 
        }

        public string ProductCode
        {
            get => txtCode.Text;
            set => txtCode.Text = value;
        }

        public decimal ProductPrice
        {
            get
            {
                decimal.TryParse(txtPrice.Text, out decimal price);
                return price;
            }
            set
            {
                txtPrice.Text = value.ToString();
            }
        }

        public int? ProductId
        {
            get
            {
                int.TryParse(hdnProductId.Value, out var id);
                return id;
            }
            set
            {
                hdnProductId.Value = value?.ToString();
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            _presenter.SaveProduct();
        }
    }
}