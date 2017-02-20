using WinForms.Framework.Messaging;

namespace IISExpressManager.AppEvents {
    public class BalloonNotificationEvent : IApplicationEvent {
        public string Title { get; set; }
        public string Message { get; set; }
        public IconType IconType { get; set; } = IconType.Info;
    }

    public enum IconType {
        Info,
        Warning,
        Error
    }
}