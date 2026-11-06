void main() {
  // const list = [11, -2, 63, 14, 0];
  // var sum = 0;
  // for (var i = 0; i < 5; i++) {
  //   print("i: $i");
  //   print("list[i]: ${list[i]}");
  //   print("sum before: $sum");

  //   sum = sum + list[i];

  //   print("sum after: $sum");
  // }

  // const list = [-9, 94, 44, 43, 42, 41];

  // var sum = 0;
  // for (var i = 0; i < 5; i++) {
  //   print("i: $i");
  //   print("list[i]: ${list[i]}");
  //   print("sum before: $sum");

  //   sum = sum + list[i];

  //   print("sum after: $sum");
  // }

  const list = [11, -2, 63, 14, 0];
  var sum = 0;
  for (var i = 0; i < list.length; i++) {
    print("i: $i");
    print("list[i]: ${list[i]}");
    print("sum before: $sum");

    sum = sum + list[i];

    print("sum after: $sum");
  }
  for (final _ in list) {}
}
