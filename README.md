# MkopaTHExercise
# How to Run

Change the value of AzureBusOption in  appsetting or appsettings.Development.json for both MKopa.App and Mkopa.ProcessSMS

Then Run the two project.

MKopa.App is a publisher that send message into the queue
MKopa.ProcessSMS is a consumer that pickup the payload and process it.
