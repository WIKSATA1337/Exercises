﻿namespace ProductShop.DTOs.Export
{
	using System.Xml.Serialization;

	[XmlType("User")]
	public class ExportUserSoldProductsDto
	{
		[XmlElement("firstName")]
		public string FirstName { get; set; } = null!;

		[XmlElement("lastName")]
		public string LastName { get; set; } = null!;

		[XmlArray("soldProducts")]
		public ExportSoldProductDto[] SoldProducts { get; set; } = null!;
	}
}
