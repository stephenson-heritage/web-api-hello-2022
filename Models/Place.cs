using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_hello;

public class Place
{

	public uint PlaceID { get; set; }

	[Required, MaxLength(128), Column(TypeName = "varchar(128)")]
	public string Name { get; set; } = "Default Place Name";

	[Required, DataType(DataType.Text)]
	public string Description { get; set; } = "Default Description";

	[Required, Column(TypeName = "decimal(8,5)")]
	public decimal Latitude { get; set; }

	[Required, Column(TypeName = "decimal(9,5)")]
	public decimal Longitude { get; set; }
}