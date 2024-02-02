import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:async';

void main() {
  runApp(const MyApp());
}

Future<WatchData> fetchWatchData() async {
  final response = await http.get(Uri.parse('http://morderboy.ru/api/watch/'));

  if (response.statusCode == 200) {
    final String jsonData = response.body.replaceAll('"', '');
    return WatchData(time: jsonData.substring(0, 8));
  } else {
    throw Exception('Failed to load watch data');
  }
}

class WatchData {
  final String time;

  WatchData({required this.time});

  factory WatchData.fromJson(Map<String, dynamic> json) {
    return WatchData(time: json['time']);
  }
}

class MyApp extends StatefulWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  late String currentTime = '';

  @override
  void initState() {
    super.initState();
    updateWatchData();

    Timer.periodic(Duration(seconds: 1), (timer) {
      updateWatchData();
    });
  }

  void updateWatchData() async {
    try {
      final response = await http.get(Uri.parse('http://morderboy.ru/api/watch/'));

      if (response.statusCode == 200) {
        final String jsonData = response.body.replaceAll('"', '');
        final String newTime = jsonData.substring(0, 8);

        setState(() {
          currentTime = newTime;
        });
      } else {
        throw Exception('Failed to load watch data');
      }
    } catch (error) {
      print(error);
    }
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Scaffold(
        backgroundColor: Colors.black,
        body: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              Container(
                width: 200,
                height: 160,
                padding: EdgeInsets.all(10),
                decoration: BoxDecoration(
                  color: Color(0xFF003764),
                  borderRadius: BorderRadius.circular(10),
                ),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    Text(
                      'До чемпионата осталось:',
                      textAlign: TextAlign.center,
                      style: Theme.of(context).textTheme.headline4!.copyWith(color: Colors.white, fontSize: 16),
                    ),
                    SizedBox(height: 10),
                    Text(
                      '$currentTime',
                      textAlign: TextAlign.center,
                      style: Theme.of(context).textTheme.bodyText1!.copyWith(color: Colors.white, fontSize: 25),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
