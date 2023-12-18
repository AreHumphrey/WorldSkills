import 'package:flutter/material.dart';

class CustomButtonLogin extends StatelessWidget {
  final VoidCallback onPressed;
  final String text;

  const CustomButtonLogin({
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
        color: const Color(0xFF003764),
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