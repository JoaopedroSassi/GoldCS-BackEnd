namespace GoldCSAPI.Extensions
{
    public static class UpdateEntityExtension
    {
        public static object UpdateEntityProperties(object oldEntity,  object newEntity)
        {
            for (int i = 0; i < newEntity.GetType().GetProperties().Length; i++)
            {
                var newProperty = newEntity.GetType().GetProperties()[i];

                if (newProperty.GetValue(newEntity) is not null)
                {
                    var oldProperty = oldEntity.GetType().GetProperty(newProperty.Name);

                    oldProperty.SetValue(oldEntity, newProperty.GetValue(newEntity));
                }
            }

            return oldEntity;
        }
    }
}
