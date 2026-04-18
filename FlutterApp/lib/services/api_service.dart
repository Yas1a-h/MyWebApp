import 'dart:convert';
import 'package:http/http.dart' as http;
import '../models/user.dart';
import '../models/patient.dart';

class ApiService {
  final String apiUrl = "http://10.0.2.2:5000/api"; 
  // ⚠️ для Android эмулятора

  Future<List<User>> getUsers() async {
    final response = await http.get(Uri.parse('$apiUrl/user'));

    if (response.statusCode == 200) {
      List data = jsonDecode(response.body);
      return data.map((e) => User.fromJson(e)).toList();
    } else {
      throw Exception("Failed to load users");
    }
  }

  Future<List<Patient>> getPatients() async {
    final response = await http.get(Uri.parse('$apiUrl/patient'));

    if (response.statusCode == 200) {
      List data = jsonDecode(response.body);
      return data.map((e) => Patient.fromJson(e)).toList();
    } else {
      throw Exception("Failed to load patients");
    }
  }

  Future<void> createUser(User user) async {
    await http.post(
      Uri.parse('$apiUrl/user'),
      headers: {"Content-Type": "application/json"},
      body: jsonEncode({
        "id": user.id,
        "name": user.name,
        "email": user.email,
      }),
    );
  }

  Future<void> deleteUser(int id) async {
    await http.delete(Uri.parse('$apiUrl/user/$id'));
  }
}