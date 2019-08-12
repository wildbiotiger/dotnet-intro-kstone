from app import db


class Ship(db.Model):
    __tablename__ = "ship"

    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String)

    def __repr__(self):
        return "{}".format(self.name)

class Port(db.Model):
	__tablename__ = "port"

	id = db.Column(db.Integer, primary_key=True)
	name = db.Column(db.String)

	def __repr__(self):
		return "{}".format(self.name)

class Pirate(db.Model):
    """"""
    __tablename__ = "pirates"

    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String)
    good_or_evil = db.Column(db.String)

    ship_id = db.Column(db.Integer, db.ForeignKey("ship.id"))
    ship = db.relationship("Ship", backref=db.backref(
        "ship", order_by=id), lazy=True)
    port_id = db.Column(db.Integer, db.ForeignKey("port.id"))
    port = db.relationship("Port", backref=db.backref(
    	"port", order_by=id), lazy=True)