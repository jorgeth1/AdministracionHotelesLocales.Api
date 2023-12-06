namespace AdministracionHotelesLocales.Domain.Entities.Base
{
    internal interface IEntityBase<TId>
    {
        TId Id { get; set; }
    }
}
