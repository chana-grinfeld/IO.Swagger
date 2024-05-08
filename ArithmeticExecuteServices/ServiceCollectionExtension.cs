using ArithmeticExecuteServices.Services.Implementations;
using ArithmeticExecuteServices.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArithmeticExecuteServices.Services
{
    public static class ServiceCollectionExtension
    {
        //DependencyInjection תאפשר שימוש ב IServiceCollection התקנת הספרייה    
        // IServiceCollection היא מוגדרת כפונקציית הרחבה עבור
        //מסומנת כסטטית כדי לציין שמדובר בפונקציית עזר שניתן לקרוא ישירות למחלקה
        //IServiceCollection ללא צורך במופע של המחלקה
        //עוזר לשמור על קוד מאורגן והוספת שירותים חדשים
        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            //DI container - 
            // משמשת להוספת רישום של שירות לקונטיינר ההתלמדות
            //באופן שהשירות ייבנה פעם אחת לכל טווח החיים(scope) שנקבע על ידי AddScoped.
            //בדרך כלל, שימוש בבדרך כלל, שימוש ב-AddScoped מתאים לסיטואציות בהן תרצה לשתף בין מספר אבידקטים (dependencies) באותו scope
            //ושכן תרצה שהמרכיבים שומרים על יחס חיי משותפים.

            serviceCollection.AddScoped<IArithmeticExecuteService, ArithmeticExecuteService>();
            serviceCollection.AddScoped<IAuthorizeService, AuthorizeService>();
        }
    }
}