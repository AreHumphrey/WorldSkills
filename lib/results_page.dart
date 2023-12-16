import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'main.dart';


class ResultsPage extends StatefulWidget {
  @override
  _ResultsPageState createState() => _ResultsPageState();
}


class _ResultsPageState extends State<ResultsPage> {
  Map<dynamic, dynamic> results = {};
  String token = GlobalToken().token;

  @override
  void initState() {
    super.initState();
    fetchResults();
  }



  Future<void> fetchResults() async {
    if (!GlobalToken().isTokenValid()) {
      return;
    }

    try {
      final url = Uri.parse('http://morderboy.ru/api/getresults');
      Map<String, String> headers = {
        'Authorization': 'Bearer ${token}',
      };
      final response = await http.get(url, headers: headers);

      if (response.statusCode == 200) {
        final Map<dynamic, dynamic> responseData = json.decode(response.body);

        if (responseData.containsKey("Result 1")) {
          setState(() {
            results = responseData;
          });
        } else {
          print('No results found in the response');
        }
      } else if (response.statusCode == 404) {
        final Map<dynamic, dynamic> errorResponse = json.decode(response.body);
        String errorMessage = errorResponse['error'];
        print('Error: $errorMessage');
      } else {
        print('Failed to fetch results: ${response.statusCode}');
      }
    } catch (e) {
      print('Error fetching results: $e');
    }
  }



  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        padding: EdgeInsets.all(20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            SizedBox(height: 80),


            Center(
              child: Positioned(
                top: 100,
                child: Text(
                  'Результаты',
                  style: TextStyle(
                    fontSize: 35,
                    fontWeight: FontWeight.w700,
                    color: Color(0xFF003764),
                  ),
                ),
              ),
            ),


            ListView.builder(
              physics: NeverScrollableScrollPhysics(),
              shrinkWrap: true,
              itemCount: results.length,
              itemBuilder: (context, index) {
                final result = results['Result ${index + 1}'];
                return Padding(
                  padding: EdgeInsets.all(2.0),
                  child: Container(
                    margin: EdgeInsets.all(12.0),
                    decoration: BoxDecoration(
                        boxShadow: [
                          BoxShadow(
                            color: Color(0x40000000),
                            offset: Offset(0, 4),
                            blurRadius: 4,
                          ),
                        ],
                        borderRadius: BorderRadius.circular(10),
                        color: Color(0xFFFFFFFF)),
                    padding: EdgeInsets.all(16),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        SizedBox(height: 20),
                        ListTile(
                          subtitle: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: <Widget>[

                              Text(
                                'Чемпионат:\t\t  ${result['ChampName']}',
                                style: TextStyle(
                                    fontWeight: FontWeight.bold,
                                    fontSize: 16,
                                    color: Colors.grey[700]),
                              ),

                              SizedBox(height: 10),
                              Divider(color: Colors.grey[600]),
                              SizedBox(height: 15),

                              Text(
                                'Компетенция:\t\t  ${result['Competence']}',
                                style: TextStyle(
                                    fontWeight: FontWeight.bold,
                                    fontSize: 16,
                                    color: Colors.grey[700]),
                              ),
                              SizedBox(height: 10),
                              Divider(color: Colors.grey[600]),
                              SizedBox(height: 15),

                              Text(
                                'ID участника:\t\t ${result['ParticipantID']}',
                                style: TextStyle(
                                    fontWeight: FontWeight.bold,
                                    fontSize: 16,
                                    color: Colors.grey[700]),
                              ),

                              SizedBox(height: 10),
                              Divider(color: Colors.grey[600]),
                              SizedBox(height: 15),

                              Text(
                                'Модули:\t\t  ${result['Module']}',
                                style: TextStyle(
                                    fontWeight: FontWeight.bold,
                                    fontSize: 16,
                                    color: Colors.grey[700]),
                              ),

                              SizedBox(height: 10),
                              Divider(color: Colors.grey[600]),
                              SizedBox(height: 15),

                              Text(
                                'Итог:\t\t  ${result['Grade']}',
                                style: TextStyle(
                                    fontWeight: FontWeight.bold,
                                    fontSize: 18,
                                    color: Color(0xFFB0183D)),
                              ),

                              SizedBox(height: 10),
                              Divider(color: Colors.grey[600]),
                              SizedBox(height: 15),

                            ],
                          ),
                        ),
                        SizedBox(height: 10),
                      ],
                    ),
                  ),
                );
              },
            ),
            SizedBox(height: 130),
          ],
        ),
      ),
    );
  }
}
