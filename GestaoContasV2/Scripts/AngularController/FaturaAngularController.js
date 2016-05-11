



(function () {
    
    angular.module("FaturaAngularController", ['ngAnimate','ui.bootstrap'])
    .controller("AngularJs_FaturaController",
    ["$scope", "$timeout", "$rootScope", "$window", "$http",
    function ($scope, $timeout, $rootScope, $window, $http) {
       
        $scope.COD_FATU = 0;
        $scope.COD_CONT = 0;
        $scope.COD_USUA = document.cookie.replace("SESSAO=", "").split("&")[0].split("=")[1];
        $scope.DES_FATU = "";
        $scope.DAT_UPLO_FATU = "";
        $scope.DAT_VENC_FATU = "";
        $scope.IMG_BOLE_FATU = "";
        $scope.IND_STAT_FATU = "";
        $scope.SelectedFileForUpload = "";
        $scope.content = "";

        $scope.showAdd = true;
        $scope.addEdit = false;
        $scope.showFatura = false;

        selectDetalharConta($scope.COD_USUA);

        function selectDetalharConta(CodigoUsuario) {
            
            var data1 = $.param({
                nomeConta: null,
                descricaoConta: null,
                codigoUsuario: CodigoUsuario,
            });

            $http.get('/api/conta/selecionarConta?' + data1).success(function (data) {
                
                $scope.Contas = data;

                $scope.showAdd = false;
                $scope.addEdit = false;
                $scope.showFatura = false;
            })
           .error(function (data) {
               $scope.error = "An Error has occured while loading posts!";
           });
        }

        $scope.selectFileforUpload = function (file) {
            $scope.SelectedFileForUpload = file[0];
        }

        $scope.consultarFatura = function (Codigo) {
            
            selectDetalharFatura(Codigo);
        }
        
        function selectDetalharFatura(CodigoConta) {

            var data1 = $.param({
                descricaoFatura: null,
                codigoConta: CodigoConta,
                codigoFatura: 0,
            });
           
            $http.get('/api/fatura/selecionarFatura?' + data1).success(function (data) {
               
                $scope.Faturas = data;

                $scope.showAdd = true;
                $scope.addEdit = false;
                $scope.showFatura = false;

            })
           .error(function (data) {
               $scope.error = "An Error has occured while loading posts!";
           });
        }

        $scope.GenerateFileType = function (fileExtension) {
            switch (fileExtension.toLowerCase()) {
                case "doc":
                case "docx":
                    $scope.FileType = "application/msword";
                    break;
                case "xls":
                case "xlsx":
                    $scope.FileType = "application/vnd.ms-excel";
                    break;
                case "pps":
                case "ppt":
                    $scope.FileType = "application/vnd.ms-powerpoint";
                    break;
                case "txt":
                    $scope.FileType = "text/plain";
                    break;
                case "rtf":
                    $scope.FileType = "application/rtf";
                    break;
                case "pdf":
                    $scope.FileType = "application/pdf";
                    break;
                case "msg":
                case "eml":
                    $scope.FileType = "application/vnd.ms-outlook";
                    break;
                case "gif":
                case "bmp":
                case "png":
                case "jpg":
                    $scope.FileType = "image/JPEG";
                    break;
                case "dwg":
                    $scope.FileType = "application/acad";
                    break;
                case "zip":
                    $scope.FileType = "application/x-zip-compressed";
                    break;
                case "rar":
                    $scope.FileType = "application/x-rar-compressed";
                    break;
            }
        }

        //Search
        $scope.searchDetails = function () {

            selectDetalharFatura($scope.COD_CONT);
        }

        //Edit Student Details
        $scope.faturaEditar = function contaEditar(COD_FATU, COD_CONT, DES_FATU
                                                 ,DAT_UPLO_FATU, DAT_VENC_FATU
                                                 ,IMG_BOLE_FATU, IND_STAT_FATU) {
                        
            
            cleardetails();
            $scope.COD_FATU = COD_FATU;
            $scope.COD_CONT = COD_CONT;
            $scope.DES_FATU = DES_FATU;
            $scope.DAT_UPLO_FATU = new Date(DAT_UPLO_FATU);
            $scope.DAT_VENC_FATU = new Date(DAT_VENC_FATU);
            $scope.IMG_BOLE_FATU = "";
            $scope.IND_STAT_FATU = IND_STAT_FATU;

            $scope.showAdd = true;
            $scope.addEdit = true;
            $scope.showFatura = false;
        }

        //Delete Dtudent Detail
        $scope.faturaDelete = function faturaDelete(codigo, nome, codigoConta) {

            cleardetails();

            var delConfirm = confirm("Deseja realizar a deleção da conta " + nome + " ?");
            if (delConfirm == true) {

                var data = $.param({ codigoFatura: codigo, codigoConta: codigoConta });

                $http.delete('/api/fatura/deletarFatura?' + data).success(function (data) {
                    alert("Operação efetuado com sucesso!");
                    cleardetails();
                    selectDetalharConta($scope.COD_USUA);
                    selectDetalharFatura(codigoConta);
                })
                .error(function (data) {
                    $scope.error = "An Error has occured while loading posts!";
                });

            }
        }

        // New Student Add Details
        $scope.atualizarValorData = function (id, valor) {

           
            debugger;
            $scope.id = valor;
        }


        // New Student Add Details
        $scope.exibirCadastro = function () {
           
            cleardetails();

            $scope.showAdd = true;
            $scope.addEdit = true;
            $scope.showFatura = false;
        }

        // New Student Add Details
        $scope.exibirFatura = function exibirFatura(data) {
            
            var data1 = $.param({
                codigoFatura: data
            });

            $scope.content = '/api/faturadetalhe/selecionarFatura?' + data1;
           
            $('#myModal').modal('show');
        }

        //clear all the control values after insert and edit.
        function cleardetails() {
            
            $scope.COD_FATU = 0;
            $scope.COD_CONT = 0;
            $scope.DES_FATU = "";
            $scope.DAT_UPLO_FATU = "";
            $scope.DAT_VENC_FATU = "";
            $scope.IMG_BOLE_FATU = "";
            $scope.IND_STAT_FATU = "";

            $scope.showAdd = false;
            $scope.addEdit = false;
            $scope.showFatura = false;
        }

        //Form Validation
        $scope.Message = "";
        $scope.IsFormSubmitted = false;

        $scope.IsFormValid = false;


        $scope.$watch("formSalvar.$valid", function (isValid) {           
            $scope.IsFormValid = isValid;
        });

        //Save Student
        $scope.salvarFatura = function () {
            
            $scope.IsFormSubmitted = true;
            if ($scope.IsFormValid) {
                
                var formData = new FormData();
                formData.append("file", document.getElementById('file').files[0]);
                
                $scope.tbcc006 = {
                    COD_FATU: $scope.COD_FATU,
                    COD_CONT: $scope.COD_CONT,
                    DES_FATU: $scope.DES_FATU,
                    DAT_UPLO_FATU: $scope.DAT_UPLO_FATU,
                    DAT_VENC_FATU: $scope.DAT_VENC_FATU,
                    IMG_BOLE_FATU: null,
                    IND_STAT_FATU: 'A'
                };

                formData.append("tbcc006", angular.toJson($scope.tbcc006));
                                
                if ($scope.COD_FATU == 0) {

                    $http.post('/api/fatura/Post/', formData, {
                        
                        headers: { 'Content-Type': undefined },
                        transformRequest: angular.identity
                    }).success(function (data) {
                    

                        $scope.retornoInserir = data;
                        alert('Operação efetuado com sucesso!');

                        cleardetails();

                        selectDetalharConta($scope.COD_USUA);
                        selectDetalharFatura($scope.COD_CONT);

                    })
             .error(function () {
                 $scope.error = "An Error has occured while loading posts!";
                 alert('Ocorreu um problema no processamento da inclusão!');
             });
                }
                else {  

                    $http.put('/api/fatura/Put/', formData, {

                        headers: { 'Content-Type': undefined },
                        transformRequest: angular.identity
                    }).success(function (data) {
                        $scope.retornoAlterar = data;
                        alert('Operação efetuado com sucesso!');

                        cleardetails();

                        selectDetalharConta($scope.COD_USUA);
                        selectDetalharFatura($scope.COD_CONT);

                    })
            .error(function () {
                $scope.error = "An Error has occured while loading posts!";
                alert('Ocorreu um problema no processamento da alteração!');
            });
                }

            }
            else {
                $scope.Message = "All the fields are required.";
                alert('Campos obrigatórios não preenchidos');
            }
        }

        $scope.today = function () {
            
            $scope.DAT_UPLO_FATU = new Date();
            $scope.DAT_VENC_FATU = new Date();
        };
        $scope.today();

        $scope.clear = function () {
            
            $scope.DAT_UPLO_FATU = null;
            $scope.DAT_VENC_FATU = null;
        };

        $scope.inlineOptions = {
            customClass: getDayClass,
            minDate: new Date(),
            showWeeks: true
        };

        $scope.dateOptions = {
            dateDisabled: disabled,
            formatYear: 'yy',
            maxDate: new Date(2020, 5, 22),
            minDate: new Date(),
            startingDay: 1
        };

        // Disable weekend selection
        function disabled(data) {
            var date = data.date,
              mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        }

        $scope.toggleMin = function () {
            $scope.inlineOptions.minDate = $scope.inlineOptions.minDate ? null : new Date();
            $scope.dateOptions.minDate = $scope.inlineOptions.minDate;
        };

        $scope.toggleMin();

        $scope.open1 = function () {
           
            $scope.popup1.Opened = true;
           
        };

        $scope.open2 = function () {
            $scope.popup2.Opened = true;
        };

        $scope.setDate = function (year, month, day) {

            $scope.DAT_UPLO_FATU = new Date(year, month, day);
            $scope.DAT_VENC_FATU = new Date(year, month, day);
            //$scope.dt = new Date(year, month, day);
        };

        

        $scope.popup1 = {
            Opened: false
        };

        $scope.popup2 = {
            Opened: false
        };

        var tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);
        var afterTomorrow = new Date();
        afterTomorrow.setDate(tomorrow.getDate() + 1);
        $scope.events = [
          {
              date: tomorrow,
              status: 'full'
          },
          {
              date: afterTomorrow,
              status: 'partially'
          }
        ];

        function getDayClass(data) {
            var date = data.date,
              mode = data.mode;
            if (mode === 'day') {
                var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

                for (var i = 0; i < $scope.events.length; i++) {
                    var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                    if (dayToCheck === currentDay) {
                        return $scope.events[i].status;
                    }
                }
            }

            return '';
        }
       
    }]);
}());