class Patient {
  final String firstName;
  final String lastName;
  final String pesel;

  Patient({
    required this.firstName,
    required this.lastName,
    required this.pesel,
  });

  factory Patient.fromJson(Map<String, dynamic> json) {
    return Patient(
      firstName: json['firstName'] ?? '',
      lastName: json['lastName'] ?? '',
      pesel: json['pesel'] ?? '',
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'firstName': firstName,
      'lastName': lastName,
      'pesel': pesel,
    };
  }

  String get name => '$firstName $lastName';
}
