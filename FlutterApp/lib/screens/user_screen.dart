import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../providers/user_provider.dart';
import '../services/api_service.dart';
import '../models/user.dart';

class UserScreen extends StatelessWidget {
  const UserScreen({super.key});

  @override
  Widget build(BuildContext context) {
    final provider = Provider.of<UserProvider>(context);

    return Scaffold(
      appBar: AppBar(title: const Text('Users')),
      body: provider.users.isEmpty
          ? Center(
              child: ElevatedButton(
                onPressed: () {
                  provider.fetchUsers();
                },
                child: const Text('Load Users'),
              ),
            )
          : ListView.builder(
              itemCount: provider.users.length,
              itemBuilder: (context, index) {
                final user = provider.users[index];
                return ListTile(
                  title: Text(user.name),
                  subtitle: Text(user.email),
                );
              },
            ),
      floatingActionButton: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          FloatingActionButton(
            heroTag: 'refresh',
            onPressed: () async {
              await provider.fetchUsers();
            },
            child: const Icon(Icons.refresh),
          ),
          const SizedBox(height: 12),
          FloatingActionButton(
            heroTag: 'add',
            onPressed: () async {
              await ApiService().createUser(
                User(id: 0, name: 'New User', email: 'test@mail.com'),
              );
              await provider.fetchUsers();
            },
            child: const Icon(Icons.add),
          ),
        ],
      ),
    );
  }
}