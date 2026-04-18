import 'package:flutter/material.dart';
import '../services/api_service.dart';
import'../models/patient.dart'; 

class PatientScreen extends StatefulWidget {
  const PatientScreen({super.key});

  @override
  _PatientScreenState createState() => _PatientScreenState();
}

class _PatientScreenState extends State<PatientScreen> {
  List<Patient> patients = [];
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    _fetchPatients();
  }

  Future<void> _fetchPatients() async {
    try {
      final fetchedPatients = await ApiService().getPatients();
      setState(() {
        patients = fetchedPatients;
        isLoading = false;
      });
    } catch (e) {
      setState(() {
        isLoading = false;
      });
      // Handle error, e.g., show a snackbar
      if (mounted) {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Failed to load patients: $e')),
        );
      }
    }
  }



  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Patients'),
      ),
      body: isLoading
          ? Center(child: CircularProgressIndicator())
          : patients.isEmpty
              ? Center(child: Text('No patients found'))
              : ListView.builder(
                  itemCount: patients.length,
                  itemBuilder: (context, index) {
                    return ListTile(
                      title: Text('${patients[index].firstName} ${patients[index].lastName}'),
                    );
                  },
                ),
    );
  }
}
