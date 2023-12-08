import 'package:flutter/material.dart';

class CustomButtonRegistration extends StatelessWidget {
  final VoidCallback onPressed;
  final String text;

  const CustomButtonRegistration({
    Key? key,
    required this.onPressed,
    required this.text,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 390.16553,
      height: 50.31846,
      decoration: BoxDecoration(
        color: const Color(0xFFB0183D),
        borderRadius: BorderRadius.circular(29.68789),
      ),
      child: ElevatedButton(
        onPressed: onPressed,
        child: Text(
          text,
          style: TextStyle(
            color: Colors.white,
            fontSize: 22,
          ),
        ),
        style: ElevatedButton.styleFrom(
          primary: Colors.transparent,
          onPrimary: Colors.transparent,
          onSurface: Colors.transparent,
          shadowColor: Colors.transparent,
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(29.68789),
          ),
        ),
      ),
    );
  }
}