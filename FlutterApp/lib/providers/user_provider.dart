import 'package:flutter/material.dart';
import '../models/user.dart';
import '../services/api_service.dart';

class UserProvider with ChangeNotifier {
  List<User> _users = [];

  List<User> get users => _users;

  Future<void> fetchUsers() async {
    _users = await ApiService().getUsers();
    notifyListeners();
  }
}