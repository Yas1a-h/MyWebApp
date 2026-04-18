abstract interface class NotificationFactory{
  String send(String message);
}

class EmailNotificationFactory implements NotificationFactory{
  @override
  String send(String message) {
    return "Email sent: $message";
  }
}



class SMSNotificationFactory implements NotificationFactory{
  @override
  String send(String message) {
    return "SMS sent: $message";
  }
}




final class NotificationFactoryProvider {
  static NotificationFactory getFactory(String type) {
    switch (type) {
      case 'email':
        return EmailNotificationFactory();
      case 'sms':
        return SMSNotificationFactory();
      default:
        throw ArgumentError('Unknown notification type: $type');
    }
  }
}