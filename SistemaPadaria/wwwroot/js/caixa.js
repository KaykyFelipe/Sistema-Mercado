function submitAutomatico() {
    var codigo = $('#codigoBarrasInput').val();
    if (codigo.length === 12) {
        $.ajax({
            url: '/Caixa/AdicionarProdutoCaixa',
            type: 'POST',
            data: { codigoBarras: codigo },
            success: function (produto) {
                if (produto) {
                    adicionarProdutoNaTabela(produto);
                    // Limpa o campo de input após adicionar o produto
                    $('#codigoBarrasInput').val('');
                } else {
                    alert("Produto não encontrado.");
                    // Limpa o campo de input mesmo quando o produto não é encontrado
                    $('#codigoBarrasInput').val('');
                }
            }
        });
    }
}

function adicionarProdutoNaTabela(produto) {
    var produtoExistente = $('#tabelaProdutos tr').filter(function () {
        return $(this).find('td:first').text() === produto.codigoBarras;
    });

    if (produto.medida === 'Unidade' && produtoExistente.length > 0) {
        var inputQuantidade = produtoExistente.find('input');
        var quantidadeAtual = parseInt(inputQuantidade.val());
        inputQuantidade.val(quantidadeAtual + 1);
        atualizarTotalProduto(inputQuantidade[0]); // Atualiza o total com a nova quantidade
    } else {
        var linha = '<tr>' +
            '<td>' + produto.codigoBarras + '</td>' +
            '<td>' + produto.nome + '</td>' +
            '<td>' + produto.valor + '</td>' +
            '<td>' + '<input type="number" min="1" value="1" data-valor="' + produto.valor + '" data-medida="' + produto.medida + '" onchange="atualizarTotalProduto(this)">' + '</td>' +
            '<td>' + produto.medida + '</td>' +
            '<td><button class="btn btn-danger" onclick="removerProduto(this, ' + produto.valor + ')">Remover</button></td>' +
            '</tr>';
        $('#tabelaProdutos').append(linha);
        atualizarTotal(produto.valor); // Adiciona o valor inicial
    }
}

function atualizarTotalProduto(input) {
    var valorUnitario = parseFloat($(input).attr('data-valor'));
    var medida = $(input).attr('data-medida');
    var quantidade = parseFloat(input.value);

    // Verifica se a quantidade é um número válido
    if (isNaN(quantidade) || quantidade < 1) {
        quantidade = 1;
        input.value = 1;
    }

    var valorTotalAtual = parseFloat($(input).attr('data-valor-total')) || valorUnitario;
    var valorNovoTotal = 0;

    if (medida === 'Unidade') {
        valorNovoTotal = valorUnitario * quantidade;
    } else if (medida === 'Gramas') {
        valorNovoTotal = valorUnitario * (quantidade / 1000); // 1000 gramas = 1 kg
    }

    var diferenca = valorNovoTotal - valorTotalAtual;
    $(input).attr('data-valor-total', valorNovoTotal);

    atualizarTotal(diferenca);
}

function atualizarTotal(diferenca) {
    var total = parseFloat($('#totalValor').text());
    total += diferenca;
    if (isNaN(total) || total < 0) {
        total = 0; // Previne valores negativos e NaN
    }
    $('#totalValor').text(total.toFixed(2));
    calcularTroco(); // Atualiza o troco sempre que o total for atualizado
}

function removerProduto(button, valorProduto) {
    var row = $(button).closest('tr');
    var inputQuantidade = row.find('input');
    var quantidade = parseFloat(inputQuantidade.val());
    var medida = inputQuantidade.attr('data-medida');
    
    if (medida === 'Unidade') {
        atualizarTotal(-valorProduto * quantidade);
    } else if (medida === 'Gramas') {
        atualizarTotal(-valorProduto * (quantidade / 1000));
    }
    
    row.remove();
}

function calcularTroco() {
    var total = parseFloat($('#totalValor').text());
    var valorPago = parseFloat($('#valorPago').val());
    
    if (!isNaN(total) && !isNaN(valorPago)) {
        var troco = valorPago - total;
        $('#troco').text(troco.toFixed(2));
    } else {
        $('#troco').text('0.00');
    }
}
