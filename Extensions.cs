using Grand.Domain.Localization;
using Grand.Infrastructure.Mapper;
using Grand.Web.Common.Models;
using System.Reflection;
using Widgets.CustomForm.Domain;
using Widgets.CustomForm.Models;

namespace Widgets.CustomForm
{
    public static class Extensions
    {
        public static CustomFormModel ToModel(this CustomFormDomain entity)
        {
            return entity.MapTo<CustomFormDomain, CustomFormModel>();
        }

        public static CustomFormDomain ToEntity(this CustomFormModel model)
        {
            return model.MapTo<CustomFormModel, CustomFormDomain>();
        }

        public static CustomFormInListModel ToListModel(this CustomFormDomain entity)
        {
            return entity.MapTo<CustomFormDomain, CustomFormInListModel>();
        }

        public static List<TranslationEntity> ToLocalizedProperty<T>(this IList<T> list) where T : ILocalizedModelLocal
        {
            var local = new List<TranslationEntity>();
            foreach (var item in list)
            {
                Type[] interfaces = item.GetType().GetInterfaces();
                PropertyInfo[] props = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                foreach (var prop in props)
                {
                    bool insert = true;

                    foreach (var i in interfaces)
                    {
                        if (i.HasProperty(prop.Name))
                        {
                            insert = false;
                        }
                    }

                    if (insert && prop.GetValue(item) != null)
                        local.Add(new TranslationEntity() {
                            LanguageId = item.LanguageId,
                            LocaleKey = prop.Name,
                            LocaleValue = prop.GetValue(item).ToString(),
                        });
                }
            }
            return local;
        }

        public static bool HasProperty(this Type obj, string propertyName)
        {
            return obj.GetProperty(propertyName) != null;
        }
    }
}
