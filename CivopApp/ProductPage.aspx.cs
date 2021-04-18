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
        private const string RETURN_URL = "~/Products";

        public ProductPage()
        {
            _presenter = new ProductPresenter(this, DbContext);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.OnLoadPage();
            if (Page.IsPostBack) return;
            var productId = Request.QueryString["productId"];
            _presenter.LoadProduct(productId);
            btnDelete.Visible = ProductId != null;
        }

        /// <summary>
        /// Editovaný produkt, je null, pokud jde o vytváření nového produktu
        /// </summary>
        public Product Product { get; set; }

        /// <inheritdoc/>
        public string ProductName
        {
            get => txtName.Text;
            set => txtName.Text = value; 
        }

        /// <inheritdoc/>
        public string ProductCode
        {
            get => txtCode.Text;
            set => txtCode.Text = value;
        }

        /// <inheritdoc/>
        public decimal ProductPrice
        {
            get
            {
                decimal.TryParse(txtPrice.Text, out decimal price);
                return price;
            }
            set => txtPrice.Text = value.ToString();
        }

        /// <inheritdoc/>
        public int? ProductId
        {
            get
            {
                if (int.TryParse(hdnProductId.Value, out var id))
                    return id;
                return
                    null;
            }
            set => hdnProductId.Value = value.ToString();
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            _presenter.SaveProduct();
            Response.Redirect(RETURN_URL);
        }

        protected void btnSubmit_Delete(object sender, EventArgs e)
        {
            _presenter.DeleteProduct();
            Response.Redirect(RETURN_URL);
        }
    }
}