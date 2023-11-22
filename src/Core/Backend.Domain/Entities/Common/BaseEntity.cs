namespace Backend.Domain.Entities.Common
{
	// Burada tüm Entity'ler için geçerli olacak deðiþkenleri belirtirsiniz, onlarý buradan miras alarak tekrardan kaçýnabilirsiniz.
	// Here you specify variables that will be valid for all Entities, you can avoid duplication by inheriting them from here.

	public abstract class BaseEntity : BaseEntity<int>
	{
	}


	//Burada Entitydeki Id nin tipini kendiniz deðiþtirebilirsiniz: Guid ,string vb bi þekilde deðiþken tanýmlayabilirsiniz
	//You can change the type of the Id in Entity here by yourself: you can define a variable in various ways such as Guid or string
	public abstract class BaseEntity<TIdentity> : IEntity where TIdentity : struct, IComparable, IComparable<TIdentity>, IEquatable<TIdentity>, IFormattable
	{
		public TIdentity Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
