
import 'package:flutter/material.dart';

class ProfilePage extends StatelessWidget {
  @override
  build(BuildContext context) {
    return Center(
      child: Text(
        'Профиль',
        style: Theme.of(context).textTheme.headline4,
      ),
    );
  }
}
