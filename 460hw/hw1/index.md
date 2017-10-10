# HTML, CSS & BOOTSTRAP
## Homework #1
===

## Overview
   This is the first assignment for Western Oregon's Software Engineering I course. I am required to create a basic webpage on a subject of interest to me using HTML, CSS and Bootstrap. I have worked a bit within the first two items here, although this will be my first experiece working with Bootstrap. For my topic I have chosen to create a generic modern webpage layout targeting small businesses as throughout this course I will be working towards developing a small, freelance website development business to boost my resume and provide some extra income this year.
   Alright, let's get started!

## Stage One
   I started out on this project by creating and initializing a new repo for my GitHub account. I have used GitHub in the past, but I actually only just recently started using Git Bash, though it seems simple enough (I suppose I'll find out...). 
   Now that I have created a repo to store all of my files I decided to brush up on my HTML and CSS work. I had learned a lot of it during the winter break last year, though after that I didn't have much time to keep using it, so my skills are definitely rusty.
   After picking up the basics again from a course on Udemy.com, I downloaded Bootstrap and jumped into the documentation on their site. I already had something in mind for my homepage. I really wanted to keep most of the information to one page, I don’t personally enjoy jumping around from page to page on websites, so here I am going to try and keep the layout pleasant and allow the user to move around the front page with a fixed menu bar at the top of the screen.
```html
<html>
    
    <head>
        <!-- Required meta tags -->
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

        <!-- Bootstrap CSS -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">
        <link rel="stylesheet" href="SmallBusiness.css">
        <title>Small Business Webpage</title>
        
        
    </head>

    <body>
    
        <nav class="navbar navbar-expand-lg navbar-light">
                
            <a class="navbar-brand" href="#">Your Business Name Here!</a>
            
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            
            <div class="collapse navbar-collapse" id="navbarNav">
            
                <ul class="navbar-nav">
                
                    <li class="navbar-item active">
                        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                    </li>
                    
                    <li class="navbar-item">
                        <a class="nav-link" href="#products">Products</a>
                    </li>
                    
                    <li class="navbar-item">
                        <a class="nav-link" href="#">Customer testimony</a>
                    </li>
                    
                    <li class="navbar-item">
                        <a class="nav-link" href="SmallBusiness-ContactPage.html">Contact</a>
                    </li>
                
                </ul>
            
            </div>
        </nav>
```

