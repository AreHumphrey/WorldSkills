import 'package:flutter/material.dart';

class WorldSkillsPageRus_2 extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('WorldSkills'),
      ),
      body: SingleChildScrollView(
        padding: EdgeInsets.all(20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[

            Text(
              'Целью организации декларируется развитие движения Ворлдскиллс в Российской Федерации.\n Для ее достижения определены ключевые задачи,\n которые соответствуют поручению Президента\n от 23 ноября 2019 № Пр-2391, а именно:',
              style: TextStyle(fontSize: 16),
            ),

            RichText(
              text: TextSpan(
                children: [
                  TextSpan(text: '1. ', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Colors.black,)),
                  TextSpan(text: 'содействие выбору профессии гражданами, в том числе посредством профессиональных\n проб с ориентацией на опережающую подготовку кадров\n',  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Colors.black,)),
                  TextSpan(text: '2. ', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Colors.black,)),
                  TextSpan(text: 'формирование новой производственной культуры в целях повышения производительности труда\n',  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Colors.black,)),
                  TextSpan(text: '3. ', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Colors.black,)),
                  TextSpan(text: 'создание социальных лифтов, в том числе обеспечивающих профессиональный и карьерный рост\n работников, развитие профессиональных и экспертных сообществ\n',  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Colors.black,)),
                  TextSpan(text: '4. ', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16)),
                  TextSpan(text: 'повышение квалификации кадров, включая инженерные и рабочие профессии и навыки, в том числе\n путем организации российских и международных\n соревнований по профессиональному мастерству\n',  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Colors.black,)),
                  TextSpan(text: '5. ', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Colors.black,)),
                  TextSpan(text: 'представление Российской Федерации в международных организациях Ворлдскиллс Интернешнл,\n Ворлдскиллс Европа, Ворлдскиллс Азия, а также продвижение\n передовых стандартов подготовки кадров,\n включая развитие системы независимой оценки компетенций в России \n и других странах.\n',  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Colors.black,)),
                ],
              ),
            ),


            Text(
              'Деятельность Агентства синхронизирована с достижением национальных целей. В частности,\n Ворлдскиллс Россия активно участвует в реализации национальных проектов («Образование», «Демография»,\n «Производительность труда и поддержка занятости»)'
            )

          ],
        ),
      ),
    );
  }
}
