import pyrebase
import heapq

config = {
    "apiKey": "AIzaSyCDAQbTPGgsf1STZYMYZu5mj0aOTKmNncc",
    "authDomain": "unity-5c646.firebaseapp.com",
    "databaseURL": "https://unity-5c646.firebaseio.com",
    "projectId": "unity-5c646",
    "storageBucket": "unity-5c646.appspot.com",
    "messagingSenderId": "237192113714",
    "appId": "1:237192113714:web:0231f41dcede731449962b"
}

firebase = pyrebase.initialize_app(config)

storage = firebase.storage()

database = firebase.database()

#storage.child("images/new.jpg").put("example.jpg")


from flask import *
app = Flask(__name__)

@app.route('/HighScore', methods=['GET', 'POST'])
def HighScore():
        
    if request.method == 'POST':
        mayor = False
        x = 1
        puntajes=[]
        score = request.args.get('score',default = 0, type = int)
        player = request.args.get('player', default = "default", type = str)
        database.child("/HighScores").child(player).set(score)
        all_scores = database.child("/HighScores").get()
        for x in all_scores:
            puntajes.append(x.val())
        return(str(heapq.nlargest(10,puntajes)))
        

    if request.method == 'GET':
        all_scores = database.child("/HighScores").get()
        puntajes=[]
        for x in all_scores:
            puntajes.append(x.val())
        return(str(heapq.nlargest(10,puntajes)))
"""
@app.route('/Maps', methods=['GET', 'POST'])
def HighScore():
    if request.method == 'POST':
        database.child("/Maps").set({
            '1' : 0,
            '2' : 0,
            '3' : 0,
            '4' : 0,
            '5' : 0,
            '6' : 0,
            '7' : 0,
            '8' : 0,
            '9' : 0,
            '10': 0,
        })

    if request.method == 'GET':
        all_scores = database.child("/Maps").get()
        print (all.scores())
"""


#pip install -r requirements.txt -r requirements.dev.txt
#python -m pip install --upgrade pip
#pip install pyrebase4
#pip install flask
#set FLASK_APP=app.py
#flask run


"""
if __name__=='__main__':
    app.run(debug=True)
"""





"""#################   SERVICIOS   #################

firebase.auth()     ---->   Authentication
firebase.database() ---->   Database
firebase.storage()  ---->   Storage

#################   SERVICIOS   #################"""



"""#################   DATABASE   #################
Build paths to your data
    db.child("users").child("Morty")

Save data with a unique, auto-generated, timestamp-based key
    data = {"name": "Mortimer 'Morty' Smith"}
    db.child("users").push(data)

Create your own keys
    data = {"name": "Mortimer 'Morty' Smith"}
    db.child("users").child("Morty").set(data)

Update data for an existing entry
    db.child("users").child("Morty").update({"name": "Mortiest Morty"})

Delete data for an existing entry
    db.child("users").child("Morty").remove()

MultiLocation updates
    data = {
        "users/Morty/": {
            "name": "Mortimer 'Morty' Smith"
        },
        "users/Rick/": {
            "name": "Rick Sanchez"
        }
    }
    db.update(data)

MultiLocation Writes
    data = {
        "users/"+ref.generate_key(): {
            "name": "Mortimer 'Morty' Smith"
        },
        "users/"+ref.generate_key(): {
            "name": "Rick Sanchez"
        }
    }
    db.update(data)


RETRIEVES

Retrieve Data
    users = db.child("users").get()
    print(users.val()) # {"Morty": {"name": "Mortimer 'Morty' Smith"}, "Rick": {"name": "Rick Sanchez"}}

Return the Key
    user = db.child("users").get()
    print(user.key()) # users

Return a list of objects on each of which you can call val() and key()
    all_users = db.child("users").get()
    for user in all_users.each():
        print(user.key()) # Morty
        print(user.val()) # {name": "Mortimer 'Morty' Smith"}

Return data from a path
    all_users = db.child("users").get()

Return just the keys at a particular path
    all_user_ids = db.child("users").shallow().get()



#################   DATABASE   #################"""