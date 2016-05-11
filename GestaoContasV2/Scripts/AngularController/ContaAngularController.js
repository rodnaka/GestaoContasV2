

(function() {
    
    'use strict';
   
    angular.module("ContaAngularController", ['ngAnimate'])
    .controller("AngularJs_ContaController",
        ["$scope", "$timeout", "$rootScope", "$window", "$http",
        function ($scope, $timeout, $rootScope, $window, $http) {
               
            $scope.COD_CONT = 0;            
            $scope.DES_CONT = "";
            $scope.NOM_USUA_CONT = "";
            $scope.NUM_AGEN = "";
            $scope.NUM_CONTA = "";
            $scope.NUM_DAC_CONT = "";
            $scope.COD_BANC = "";
            $scope.NUM_CNPJ_CPF = "";
            $scope.DESC_SENH_CONT = "";
            $scope.DAT_INCL_CONT = "";
            $scope.DAT_ALTE_CONT = "";
            $scope.IND_STAT_CONT = "";
            $scope.NUM_FATU_ABER = "";

            $scope.showAdd = true;
            $scope.addEdit = false;
            $scope.showList = true;
            $scope.showItem = true;

            //This variable will be used for Insert/Edit/Delete Students details.        
            $scope.stdNomeConta = "";
            $scope.stdDescricaoConta = "";

            selectDetalhar($scope.stdNomeConta, $scope.stdDescricaoConta);

            function selectDetalhar(NomeConta, DescricaoConta) {
                
                var data1 = $.param({
                    nomeConta: NomeConta,
                    descricaoConta: DescricaoConta,
                    codigoUsuario: 0,
                });
            
                $http.get('/api/conta/selecionarConta?' + data1).success(function (data) {
                
                    $scope.Contas = data;

                    $scope.showAdd = true;
                    $scope.addEdit = false;
                    $scope.showList = true;
                    $scope.showItem = true;
                })
               .error(function (data) {
                   $scope.error = "An Error has occured while loading posts!";
               });
            }        
        
            //Search
            $scope.searchDetails = function () {

                selectDetalhar($scope.stdNomeConta, $scope.stdDescricaoConta);
            }

            //Edit Student Details
            $scope.contaEditar = function contaEditar(COD_CONT, COD_USUA, DES_CONT, NOM_USUA_CONT, NUM_AGEN, NUM_CONTA, NUM_DAC_CONT
                , COD_BANC, NUM_CNPJ_CPF, DESC_SENH_CONT, DAT_INCL_CONT, DAT_ALTE_CONT, IND_STAT_CONT, NUM_FATU_ABER) {
                           
                cleardetails();
                $scope.COD_CONT = COD_CONT;
                $scope.COD_USUA = document.cookie.replace("SESSAO=", "").split("&")[0].split("=")[1];
                $scope.DES_CONT = DES_CONT;
                $scope.NOM_USUA_CONT = NOM_USUA_CONT;
                $scope.NUM_AGEN = NUM_AGEN;
                $scope.NUM_CONTA = NUM_CONTA;
                $scope.NUM_DAC_CONT = NUM_DAC_CONT;
                $scope.COD_BANC = COD_BANC;
                $scope.NUM_CNPJ_CPF = NUM_CNPJ_CPF;
                $scope.DESC_SENH_CONT = DESC_SENH_CONT;
                $scope.DAT_INCL_CONT = DAT_INCL_CONT;
                $scope.DAT_ALTE_CONT = DAT_ALTE_CONT;
                $scope.IND_STAT_CONT = IND_STAT_CONT;
                $scope.NUM_FATU_ABER = NUM_FATU_ABER;

                $scope.showAdd = true;
                $scope.addEdit = true;
                $scope.showList = true;
                $scope.showItem = true;

            }

            //Delete Dtudent Detail
            $scope.contaDelete = function contaDelete(codigo, nome) {

                cleardetails();
            
                var delConfirm = confirm("Are you sure you want to delete the Student " + nome + " ?");
                if (delConfirm == true) {

                    var data = $.param({ codigoConta: codigo });

                    $http.delete('/api/conta/deletarConta?' + data).success(function (data) {
                          alert("Student Deleted Successfully!!");
                          cleardetails();
                          selectDetalhar('', '');
                      })
                    .error(function (data) {
                        $scope.error = "An Error has occured while loading posts!";
                    });

                }
            }

            // New Student Add Details
            $scope.exibirCadastro = function () {

                cleardetails();

                $scope.showAdd = true;
                $scope.addEdit = true;
                $scope.showList = true;
                $scope.showItem = true;            
            }

            //clear all the control values after insert and edit.
            function cleardetails() {
            
                $scope.stdNome = "";
                $scope.stdEmail = "";

                $scope.COD_CONT = 0;
                $scope.COD_USUA = "";
                $scope.DES_CONT = "";
                $scope.NOM_USUA_CONT = "";
                $scope.NUM_AGEN = "";
                $scope.NUM_CONTA = "";
                $scope.NUM_DAC_CONT = "";
                $scope.COD_BANC = "";
                $scope.NUM_CNPJ_CPF = "";
                $scope.DESC_SENH_CONT = "";
                $scope.DAT_INCL_CONT = "";
                $scope.DAT_ALTE_CONT = "";
                $scope.IND_STAT_CONT = "";
                $scope.NUM_FATU_ABER = "";
            }

            //Form Validation
            $scope.Message = "";
            $scope.IsFormSubmitted = false;

            $scope.IsFormValid = false;


            $scope.$watch("formSalvar.$valid", function (isValid) {
                $scope.IsFormValid = isValid;

            });

            //Save Student
            $scope.salvarConta = function () {
               
                $scope.IsFormSubmitted = true;
                if ($scope.IsFormValid) {               

                    $scope.tbcc005 = {
                        COD_CONT: $scope.COD_CONT,
                        COD_USUA: document.cookie.replace("SESSAO=", "").split("&")[0].split("=")[1],
                        DES_CONT: $scope.DES_CONT,
                        NOM_USUA_CONT: $scope.NOM_USUA_CONT,
                        NUM_AGEN: $scope.NUM_AGEN,
                        NUM_CONTA: $scope.NUM_CONTA,
                        NUM_DAC_CONT: $scope.NUM_DAC_CONT,
                        COD_BANC: $scope.COD_BANC,
                        NUM_CNPJ_CPF: $scope.NUM_CNPJ_CPF,
                        DESC_SENH_CONT: $scope.DESC_SENH_CONT,
                        DAT_INCL_CONT: new Date(),
                        DAT_ALTE_CONT: new Date(),
                        IND_STAT_CONT: 'A',
                        NUM_FATU_ABER: $scope.NUM_FATU_ABER
                    };

                    //if the Student ID=0 means its new Student insert here i will call the Web api insert method
                    if ($scope.COD_CONT == 0) {
                    
                        $http.post('/api/conta/inserirConta/', $scope.tbcc005).success(function (data) {

                            $scope.retornoInserir = data;
                            alert('Processamento efetuado com sucesso!');

                            cleardetails();
                            selectDetalhar('', '');

                        })
                 .error(function () {
                     $scope.error = "An Error has occured while loading posts!";
                 });
                    }
                    else {  

                        $http.put('/api/conta/alterarConta/', $scope.tbcc005).success(function (data) {
                            $scope.retornoAlterar = data;
                            alert('Processamento efetuado com sucesso!');

                            cleardetails();
                            selectDetalhar('', '');

                        })
                .error(function () {
                    $scope.error = "An Error has occured while loading posts!";
                });
                    }

                }
                else {
                    $scope.Message = "All the fields are required.";
                }
            }

        }]);

}());