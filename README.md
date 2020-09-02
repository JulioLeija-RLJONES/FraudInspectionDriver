# Fraud Inspection Driver

## Application description

The main application's purpose is to drive the Chrome web browser with Selenium and automate certain operations in the FlexLink web application, the sequence is as follows:

1- Login form is shown
2- The operator enters its Flexlink username and password, then click login button (this can be made with a scanner)
3- Application tries to connect with RL Jones server on AWS and, if connection succeed, opens a Web Browser with Selenium.
4- Web browser navigates to FlexLink URL and enters the username and password previously provided by the user, then tries to login on FlexLink.
5- If login is successful, a black label is placed on top of screen giving further instructions to the operator. Otherwise, the operator will be alerted and the web browser will be closed.
6- Application will idle until operator navigates to 'Screening and Disposition' page.
7- When a serial number is scanned and verified, the application will verify if it is a fraud target on database. If it is a fraud, the fraud inspection form will appear requiring the user to enter an inspection result.
8- When inspection result is entered, the control is released to the web browser.
