(int, int, int) fixTimer(int input) {
  int hours = input ~/ 3600;
  int remainingSeconds = input % 3600;
  int minutes = remainingSeconds ~/ 60;
  int seconds = remainingSeconds % 60;
  return (hours, minutes, seconds);
}
