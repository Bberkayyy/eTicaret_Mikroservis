namespace e_Ticaret.Cargo.EntityLayer.Concrete;

public class Detail
{
    public int Id { get; set; }
    public string Sender { get; set; }
    public string ReceiverId { get; set; }
    public string BarcodeNo { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}
