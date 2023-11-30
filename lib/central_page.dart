
import 'package:flutter/material.dart';

class CentralPage extends StatelessWidget {
  @override
  build(BuildContext context) {
    return Center(
      child: Text(
        'Главная страница',
        style: Theme.of(context).textTheme.headline4,
      ),
    );
  }
}