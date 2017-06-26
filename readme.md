# Pinta Upload Add-in

This is an proof of concept add-in for uploading your images to internet hosting sites. The only upload type that has been implemented is the obsolete Imgur v1 upload API, so this addin currently does not work until someone does the job of updating it to the new API. (See issue #11)

##Notes

- It has a lib copy of the current Pinta.Core to build against, and it currently needs manual updating. (Need to look into automatic updates here.)

- It's set up for upload to a Cydin server for easy distribution. For development purposes, the generated dll can be placed in Pinta's bin folder.



## License

As with the rest of Pinta, this is licensed under the MIT/X11 license.
