import 'package:flutter/material.dart';


class CompetencyButton extends StatelessWidget {
  final String image;
  final String text;
  final VoidCallback onPressed;

  CompetencyButton(
      {required this.image, required this.text, required this.onPressed});

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onPressed,
      child: Container(
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(10),
          color: Color(0xFF0084AD),
        ),
        width: 157,
        height: 178,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Center(
              child: Image.asset(
                image,
                width: 90,
                height: 90,
                color: Colors.white,
              ),
            ),
            SizedBox(height: 25),

            Center(
              child: Text(
                text,
                textAlign: TextAlign.center,
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              ),
            )

          ],
        ),
      ),
    );
  }
}