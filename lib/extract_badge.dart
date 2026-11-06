(String group, bool isBoss) extractBadge(int badge) {
  String group;
  bool isBoss = false;
  if (badge.isEven) {
    group = "A";
    isBoss = badge % 10 == 0;
  } else {
    group = "B";
  }

  return (group, isBoss);
}
