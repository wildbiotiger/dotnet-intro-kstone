from sqlalchemy import create_engine, ForeignKey
from sqlalchemy import Column, Date, Integer, String
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import relationship, backref

engine = create_engine('sqlite:///piedball.db', echo=True)
Base = declarative_base()


class Ship(Base):
    __tablename__ = "ship"

    id = Column(Integer, primary_key=True)
    name = Column(String)

    def __repr__(self):
        return "<Ship: {}>".format(self.name)

class Port(Base):
	__tablename__ = "port"
	
	id = Column(Integer, primary_key=True)
	name = Column(String)
	
	def __repr__(self):
		return "<Port: {}>".format(self.name)
		
class Pirate(Base):
    """"""
    __tablename__ = "pirates"

    id = Column(Integer, primary_key=True)
    name = Column(String)
    good_or_evil = Column(String)

    ship_id = Column(Integer, ForeignKey("ship.id"))
    ship = relationship("Ship", backref=backref(
        "pirate", order_by=id))
    port_id = Column(Integer, ForeignKey("port.id"))
    port = relationship("Port", backref=backref(
		"pirate", order_by=id))

# create tables
Base.metadata.create_all(engine)
