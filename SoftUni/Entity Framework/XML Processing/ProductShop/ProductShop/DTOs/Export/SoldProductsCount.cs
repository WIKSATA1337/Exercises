namespace ProductShop.DTOs.Export
{
	using System.Xml.Serialization;

	[XmlType("SoldProducts")]
	public class SoldProductsCount
	{
		[XmlElement("count")]
		public int Count { get; set; }

		[XmlArray("products")]
		public SoldProduct[] Products { get; set; }
	}
}
