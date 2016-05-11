

(function() {
    
    'use strict';
   
 angular.module("LoginAngularController", ['ngAnimate'])
.controller("AngularJs_LoginController",
    ["$scope", "$timeout", "$rootScope", "$window", "$http",
    function ($scope, $timeout, $rootScope, $window, $http) {
               
        $scope.COD_USUA = 0;
        $scope.COD_ESTA_CIVI = "";
        $scope.COD_TELE = "";
        $scope.NOM_USUA = "";
        $scope.NOM_SEXO = "";
        $scope.NUM_CPF_CNPJ = "";
        $scope.NUM_RG = "";
        $scope.DES_EMAIL = "";
        $scope.NUM_SENH = "";
        $scope.NOM_ORGA_EMIS = "";
        $scope.NOM_ESTA_EMIS = "";
        $scope.NOM_MAE = "";
        $scope.NOM_PAI = "";
        $scope.DES_NATU = "";
        $scope.DAT_INCL_USUA = "";
        $scope.DAT_ALTE_USUA = new Date();
        $scope.DAT_NASC_USUA = "";
        $scope.IND_STAT_USUA = "";
        $scope.COD_ENDE = "";
        $scope.NUM_CEP = "";
        $scope.DES_LOGR = "";
        $scope.NUM_NUME = "";
        $scope.DES_COMP = "";
        $scope.DES_BAIR = "";
        $scope.DES_CIDA = "";
        $scope.DES_ESTA = "";
        $scope.NUM_DDI_CELU = "";
        $scope.NUM_DDD_CELU = "";
        $scope.NUM_TELE_CELU = "";
        $scope.NUM_DDI_FIXO = "";
        $scope.NUM_DDD_FIXO = "";
        $scope.NUM_TELE_FIXO = "";
        $scope.COD_ESTA_CIVI = "";
        $scope.DESC_ESTA_CIVI = "";
        
        $scope.stdSenha = "";
        $scope.stdEmail = "";
       
        selecionarEstadoCivilTodos();        

        function verificarUsuarioLogado() {
             

            var data1 = $.param({
                emailUsuario: $scope.stdEmail,
                senhalUsuario: $scope.stdSenha
            });
            
            $http.get('/api/login/GetUsuarioLogado?' + data1).success(function (data) {
               
                $scope.Login = data;
                
                if(data != null)                
                    $window.location.href = '/Home/Index';                
                else
                    alert('Usuário não cadastrado');
            })
           .error(function (data) {
               $scope.error = "An Error has occured while loading posts!";
               alert('Usuário não cadastrado');
           });
        }

        function selecionarEstadoCivilTodos() {
            
            $http.get('/api/usuarioestadocivil/selecionarEstadoCivilTodos').success(function (data) {

                $scope.EstadoCivil = data;
            })
           .error(function (data) {
               $scope.error = "An Error has occured while loading posts!";
           });
        }

        //Search
        $scope.searchStudentDetails = function () {
            
            verificarUsuarioLogado();
        }
                
        //Form Validation
        $scope.Message = "";
        $scope.IsFormSubmitted = false;

        $scope.IsFormValid = false;

        $scope.$watch("formSalvar.$valid", function (isValid) {
            $scope.IsFormValid = isValid;

        });

        //Save Student
        $scope.salvarUsuario = function () {            
            $scope.IsFormSubmitted = true;
            if ($scope.IsFormValid) {

                $scope.TBCCC_003_ENDE = {
                    COD_ENDE: $scope.COD_ENDE,
                    NUM_CEP: $scope.NUM_CEP,
                    DES_LOGR: $scope.DES_LOGR,
                    NUM_NUME: $scope.NUM_NUME,
                    DES_COMP: $scope.DES_COMP,
                    DES_BAIR: $scope.DES_BAIR,
                    DES_CIDA: $scope.DES_CIDA,
                    DES_ESTA: $scope.DES_ESTA
                };

                $scope.TBCCC_004_TELE = {
                    COD_TELE: $scope.COD_TELE,
                    NUM_DDI_CELU: $scope.NUM_DDI_CELU,
                    NUM_DDD_CELU: $scope.NUM_DDD_CELU,
                    NUM_TELE_CELU: $scope.NUM_TELE_CELU,
                    NUM_DDI_FIXO: $scope.NUM_DDI_FIXO,
                    NUM_DDD_FIXO: $scope.NUM_DDD_FIXO,
                    NUM_TELE_FIXO: $scope.NUM_TELE_FIXO
                };

                $scope.Usuario = {
                    DES_EMAIL: $scope.DES_EMAIL,
                    NOM_USUA: $scope.NOM_USUA,
                    NOM_SEXO: $scope.NOM_SEXO,
                    NUM_CPF_CNPJ: $scope.NUM_CPF_CNPJ,
                    NUM_RG: $scope.NUM_RG,
                    NUM_SENH: $scope.NUM_SENH,
                    NOM_ORGA_EMIS: $scope.NOM_ORGA_EMIS,
                    NOM_ESTA_EMIS: $scope.NOM_ESTA_EMIS,
                    NOM_MAE: $scope.NOM_MAE,
                    NOM_PAI: $scope.NOM_PAI,
                    DES_NATU: $scope.DES_NATU,
                    DAT_INCL_USUA: new Date(),
                    DAT_ALTE_USUA: new Date(),
                    DAT_NASC_USUA: $scope.DAT_NASC_USUA,
                    IND_STAT_USUA: 'A',
                    COD_ESTA_CIVI: $scope.COD_ESTA_CIVI,
                    TBCCC_003_ENDE: $scope.TBCCC_003_ENDE,
                    TBCCC_004_TELE: $scope.TBCCC_004_TELE
                };       
                
                $http.post('/api/login/inserirUsuario/', $scope.Usuario).success(function (data) {

                    $scope.StudentsInserted = data;
                    alert('Processamento efetuado com sucesso!');

                    cleardetails();
                    $window.location.href = '/Home/Index';
                })
             .error(function () {
                 $scope.error = "An Error has occured while loading posts!";
             });               

            }
            else {
                $scope.Message = "All the fields are required.";
            }
        }

    }]);

}());