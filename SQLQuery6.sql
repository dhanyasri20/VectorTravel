-- Step 1: Clear the table to ensure a fresh start
DELETE FROM Inspirations;
GO

-- Step 2: Insert the complete list with the new, simpler image paths
INSERT INTO Inspirations (Title, Location, ImageUrl, Category, Description) VALUES
('Santorini Sunset Magic', 'Santorini, Greece', '/images/santorini.jpg', 'Islands', 'The iconic white-washed villages glowing under a breathtaking sunset.'),
('Cherry Blossoms in Kyoto', 'Kyoto, Japan', '/images/kyoto.jpg', 'Culture', 'Ancient temples framed by delicate cherry blossoms in spring.'),
('Overwater Bungalows', 'Bora Bora, French Polynesia', '/images/borabora.jpg', 'Beaches', 'Crystal-clear turquoise waters surrounding luxurious overwater retreats.'),
('Colosseum at Dawn', 'Rome, Italy', '/images/rome.jpg', 'Ancient Cities', 'The timeless grandeur of the Colosseum emerges with the rising sun.'),
('Amber Fort Hues', 'Jaipur, India', '/images/jaipur.jpg', 'Culture', 'The majestic Amber Fort, a blend of Rajput and Hindu architectural styles.'),
('Bali Rice Terraces', 'Ubud, Bali, Indonesia', '/images/bali.jpg', 'Nature', 'Lush green rice paddies cascading down hillsides, a true tropical paradise.'),
('Eiffel Tower Charm', 'Paris, France', '/images/paris.png', 'Cityscapes', 'The iconic Eiffel Tower, a symbol of romance and architectural marvel.'),
('Na Pali Coast Majesty', 'Kauai, Hawaii, USA', '/images/napali.jpg', 'Nature', 'Dramatic cliffs and lush valleys create an unforgettable coastal landscape.'),
('Taj Mahal Serenity', 'Agra, India', '/images/tajmahal.jpg', 'Culture', 'The breathtaking marble mausoleum, a testament to eternal love.'),
('Venetian Canals', 'Venice, Italy', '/images/venice.jpg', 'Cityscapes', 'Romantic gondola rides through historic canals and charming bridges.'),
('Great Wall of China', 'Beijing, China', '/images/greatwall.jpg', 'Ancient Cities', 'An awe-inspiring ancient defensive fortification stretching across mountains.'),
('Maldivian Paradise', 'Maldives', '/images/maldives.jpg', 'Beaches', 'Pristine white-sand beaches and an amazing underwater world make it a dream destination.'),
('The Lost City of Incas', 'Machu Picchu, Peru', '/images/machupicchu.jpg', 'Ancient Cities', 'Ancient Incan city high in the Andes Mountains, known for its sophisticated dry-stone walls.'),
('Alpine Majesty', 'Swiss Alps, Switzerland', '/images/alps.jpg', 'Nature', 'Breathtaking mountain scenery, pristine lakes, and charming alpine villages.'),
('The Rose City', 'Petra, Jordan', '/images/petra.jpg', 'Ancient Cities', 'A famous archaeological site featuring tombs and temples carved into pink sandstone cliffs.'),
('Manhattan Skyline', 'New York, USA', '/images/newyork.jpg', 'Cityscapes', 'The iconic skyline of the city that never sleeps, a global center for art, culture, and finance.'),
('Aurora Borealis', 'Tromsø, Norway', '/images/aurora.jpg', 'Nature', 'Witness the magical dance of the Northern Lights in the Arctic sky, a truly unforgettable experience.');
GO 