<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestConfirm1.aspx.cs" Inherits="TEST_Confirm_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <meta charset="utf-8">
      
        <title>jquery-confirm.js | The multipurpose alert & confirm</title>
 
      
       

     
<link href="../../css/bootstrap.min.css" rel="stylesheet" />
        <%--<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>--%>
       
<script src="../../JavaScript/jquery1.11.3_jquery_min.js"></script>

  
        <!-- Add the minified version of files from the /dist/ folder. -->
        <!-- jquery-confirm files -->
        <link rel="stylesheet" type="text/css" href="css/jquery-confirm.css" />
        <script type="text/javascript" src="js/jquery-confirm.js"></script>
        <!--END jquery-confirm files-->

        


     
</head>
<body>
    
    <form id="form1" runat="server">
    <div>

  
        <!--<div style="height:50px"></div>-->
        <div class="container">
            <div class="row">
              <asp:Button ID="Button1" runat="server" OnClientClick="return fun1();" Text="Button" />
                <div class="col-md-9 col-sm-12">
                    <!-- introduction -->
                   
                    <hr>
                    <section id="Section1">
                        <h1>Quick features</h1>
                        <p>These features can practically be used like so.</p>
                        <div class="row">
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-p-1">Alerts</button>
                                <p class="text-success">Elegant Alerts.</p>
                            </div>
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-p-2">Confirmation</button>
                                <p class="text-success">Stacked Confirmations</p>
                            </div>
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-p-7-1">Act like Prompt</button>
                                <p class="text-success">Need input?</p>
                            </div>
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-p-3">Background dismiss</button>
                                <p class="text-success">Not so important modal</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-p-4">Using as dialogs/modals</button>
                                <p class="text-success">Its also a Dialog.</p>
                            </div>
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-p-5">Asynchronous content</button>
                                <p class="text-success">Loading from remote places</p>
                            </div>
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-p-6">Auto-close</button>
                                <p class="text-success">Some actions maybe critical</p>
                            </div>
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-p-7">Keystrokes</button>
                                <p class="text-success">Keyboard actions?</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-pc-1">Alignment</button>
                                <p class="text-success">Automatically centered</p>
                            </div>
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-pc-2">Images</button>
                                <p class="text-success">Loading images</p>
                            </div>
                            <div class="col-md-3">
                                <button class="btn btn-primary btn-block example-pc-3">Animations</button>
                                <p class="text-success">Clean animations</p>
                            </div>
                        </div>
              
                    </section>

              

                   

                  


      
  

                 



               
                </div>
            </div>
        </div>
    

 

                     
    </div>
    </form>
      <script type="text/javascript">

          function fun1() {
              $.alert({
                  title: 'Hey!',
                  content: 'This is a simple alert to the user. <br> with some <strong>HTML</strong> <em>contents</em>',
                  confirmButton: 'Okay',
                  confirmButtonClass: 'btn-primary',
                  icon: 'fa fa-info',
                  animation: 'zoom',
                  confirm: function () {
                      $.alert('Okay action clicked.');
                  }
              });
              return false;

          }

          $(' .example-pc-3').on('click', function () {
              $.alert({
                  title: 'Animations',
                  content: 'jquery-confirm provides 12 animations to choose from.',
                  animation: 'rotate',
                  closeAnimation: 'right',
                  opacity: 0.5
              });
              return false;
          });
          $('.example-pc-1').on('click', function () {
              $.confirm({
                  title: 'This is smoooth',
                  content: '<p>You can add content and not worry about the alignment. The goal is to make a Interactive dialog!.</p>' +
                  '<button type="button">Click me to add content</button> <span> <br></span> ',
                  confirmButtonClass: 'btn-primary',
                  animation: 'zoom',
                  onOpen: function () {
                      var that = this;
                      this.$content.find('button').click(function () {
                          that.$content.find('span').append('<br>This is awesome!!!!');
                      });
                  },
                  confirmButton: 'Say "Wowww"',
                  confirm: function () {
                      this.$content.find('span').append('<br>Wowww');
                      return false; // prevent dialog from closing.
                  }
              });
              return false;
          });
          $('.example-pc-2').on('click', function () {
              window.b = $.confirm({
                  title: 'Adding images',
                  content: 'Images from flickr <br><img src="https://c2.staticflickr.com/4/3891/14354989289_2eec0ba724_b.jpg">',
                  confirmButtonClass: 'btn-primary',
                  animation: 'zoom',
                  animationClose: 'top',
                  confirmButton: 'Add more',
                  confirm: function () {
                      this.$content.append('<img src="https://c2.staticflickr.com/6/5248/5240523362_8d6d315391_b.jpg">');
                      return false; // prevent dialog from closing.
                  }
              });
              return false;
          });
          $('.example-p-1').on('click', function () {
              alert('hi');
              $.alert({
                  title: 'Hey!',
                  content: 'This is a simple alert to the user. <br> with some <strong>HTML</strong> <em>contents</em>',
                  confirmButton: 'Okay',
                  confirmButtonClass: 'btn-primary',
                  icon: 'fa fa-info',
                  animation: 'zoom',
                  confirm: function () {
                      $.alert('Okay action clicked.');
                  }
              });
              return false;


          });
          $('.example-p-2').on('click', function () {
              $.confirm({
                  title: 'A secure action',
                  content: 'Its smooth to do multiple confirms at a time. <br> Click proceed for another modal',
                  confirmButton: 'Proceed',
                  confirmButtonClass: 'btn-info',
                  icon: 'fa fa-question-circle',
                  animation: 'scale',
                  animationClose: 'top',
                  opacity: 0.5,
                  confirm: function () {
                      $.confirm({
                          title: 'This maybe critical',
                          content: 'Critical actions can have multiple confirmations like this one.',
                          confirmButton: 'Yes, sure!',
                          icon: 'fa fa-warning',
                          confirmButtonClass: 'btn-warning',
                          animation: 'zoom',
                          confirm: function () {
                              $.alert('A very critical action triggered!');
                          }
                      });
                  }
              });
              return false;
          });
          $('.example-p-3').on('click', function () {
              $.alert({
                  title: 'Background dismiss',
                  content: 'By default the user is not allowed to click outside the modal. Click outside the modal to close.',
                  confirmButton: 'okay',
                  confirmButtonClass: 'btn-info',
                  animation: 'bottom',
                  icon: 'fa fa-check',
                  backgroundDismiss: true
              });
              return false;
          });
          $('.example-p-4').on('click', function () {
              $.confirm({
                  title: 'Title here',
                  content: 'Need a popup modal?, no problem!<br>disable the buttons, and get a full functional modal. <br><h3>HTML inside modals</h3><h4><strong>centered on the screen</strong></h4><h5><em>Like a boss</em></h5>' +
                  '<button type="button">Interactive too</button>',
                  confirmButton: false,
                  cancelButton: false,
                  animation: 'scale',
                  onOpen: function () {
                      var that = this;
                      this.$content.find('button').click(function () {
                          that.$content.html('As simple as that !');
                      })
                  }
              });
              return false;
          });
          $('.example-p-5').on('click', function () {
              $.confirm({
                  title: 'Asynchronous content',
                  content: 'url:table.html',
                  animation: 'top',
                  columnClass: 'col-md-6 col-md-offset-3',
                  closeAnimation: 'bottom',
                  backgroundDismiss: true,
              });
              return false;
          });
          $('.example-p-6').on('click', function () {
              $.confirm({
                  title: 'Auto close',
                  content: 'Some actions maybe critical, prevent it with the Auto close feature. This dialog will automatically trigger cancel after the timer runs out.',
                  autoClose: 'cancel|10000',
                  confirmButtonClass: 'btn-danger',
                  confirmButton: 'Delete Ben\'s account',
                  cancelButton: 'Close',
                  confirm: function () {
                      $.alert('You deleted Ben\'s account!');
                  },
                  cancel: function () {
                      $.alert('Ben just got saved!');
                  }
              });
              return false;
          });
          $('.example-p-7').on('click', function () {
              $.confirm({
                  title: 'Keystrokes Enabled!',
                  keyboardEnabled: true,
                  content: 'Press ENTER to confirm, ESC to cancel.<br> Use <code>keyboardEnabled:true</code> to turn it on.',
                  backgroundDismiss: true,
                  confirm: function () {
                      $.alert('confirm triggered!');
                  },
                  cancel: function () {
                      $.alert('cancel triggered!');
                  }
              });
              return false;
          });
          $('.example-p-7-1').on('click', function () {
              $.confirm({
                  title: 'A simple form',
                  content: 'url:form.txt',
                  confirm: function () {
                      var input = this.$b.find('input#input-name');
                      var errorText = this.$b.find('.text-danger');
                      if (input.val() == '') {
                          errorText.show();
                          return false;
                      } else {
                          $.alert('Hello ' + input.val());
                      }
                  }
              });
              return false;
          });
                        </script>   
</body>
</html>
