import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'bottom_nav_bar.dart';

void main() {
  debugPaintSizeEnabled = false;
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        backgroundColor: Color(0xFFE5E9EA),
      ),
      home: const BottomNavBar(),
    );
  }
}
