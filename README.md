# :carrot: Plant It
Repositório para desenvovimento do jogo "Plant It"

**Usar o Unity Editor na versão ```2022.3.5f1``` para evitar erros ao importar o projeto**
## Workflow
O repositório possui duas branches, a ```main``` e a ```dev```, as mudanças devem ser feitas na branch ```dev```

Não dê push direto para a branch ```dev```, crie uma branch nova para fazer suas alterações

![workflow](https://wac-cdn.atlassian.com/dam/jcr:34c86360-8dea-4be4-92f7-6597d4d5bfae/02%20Feature%20branches.svg?cdnVersion=1137)


```
1. Crie uma nova branch
git checkout branch -b feature-<nomeDoFeature>

1a. Verifique se está na branch certa
git branch

2. Faça os commits na branch
git commit -m "<mensagem do commit>"

3. Dê push na sua branch
git push --set-upstream origin <nomeDaBranch>

4. Faça um pull request para aplicar as mudanças na branch dev

```
