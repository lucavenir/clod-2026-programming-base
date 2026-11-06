[tools]
dotnet = "10"

[tasks.setup]
description = "Installa VS Code e C# Dev Kit"
run = """
#!/usr/bin/env bash
set -e

echo "Verifica .NET SDK..."
dotnet --version

echo "Installazione Visual Studio Code..."
if ! command -v code >/dev/null 2>&1; then
  if command -v apt-get >/dev/null 2>&1; then
    sudo snap install code --classic
  elif command -v brew >/dev/null 2>&1; then
    brew install --cask visual-studio-code
  else
    echo "Installa VS Code manualmente."
    exit 1
  fi
fi

echo "Installazione C# Dev Kit..."
code --install-extension ms-dotnettools.csdevkit --force

echo "Ambiente .NET pronto!"
"""