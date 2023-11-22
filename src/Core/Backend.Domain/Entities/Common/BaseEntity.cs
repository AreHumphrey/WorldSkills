namespace Backend.Domain.Entities.Common
{
	// Burada t�m Entity'ler i�in ge�erli olacak de�i�kenleri belirtirsiniz, onlar� buradan miras alarak tekrardan ka��nabilirsiniz.
	// Here you specify variables that will be valid for all Entities, you can avoid duplication by inheriting them from here.

	public abstract class BaseEntity : BaseEntity<int>
	{
	}


	//Burada Entitydeki Id nin tipini kendiniz de�i�tirebilirsiniz: Guid ,string vb bi �ekilde de�i�ken tan�mlayabilirsiniz
	//You can change the type of the Id in Entity here by yourself: you can define a variable in various ways such as Guid or string
	public abstract class BaseEntity<TIdentity> : IEntity where TIdentity : struct, IComparable, IComparable<TIdentity>, IEquatable<TIdentity>, IFormattable
	{
		public TIdentity Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
