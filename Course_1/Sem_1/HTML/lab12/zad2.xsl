<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<head>
				<title>Номер 2</title>
			</head>
			<body>
				<h2 align="center">Упражнение 2</h2>
				<table border="1" width="600px" height="500px">
					<tr bgcolor="blue">
						<th>Имя</th>
						<th>Оценка</th>
					</tr>
					<xsl:for-each select="catalog/cd">
						<tr>
							<td>
								<xsl:value-of select="name"/>
							</td>
							<xsl:choose>
								<xsl:when test="mark &lt; 4">
									<td bgcolor="#ff0000">
										<xsl:value-of select="mark"/>
									</td>
								</xsl:when>
								<xsl:when test="mark &gt; 8">
									<td bgcolor="#008000">
										<xsl:value-of select="mark"/>
									</td>
								</xsl:when>
								<xsl:when test="mark=7">
									<td bgcolor="brown">
										<xsl:value-of select="mark"/>
									</td>
								</xsl:when>
								<xsl:otherwise>
									<td bgcolor="yellow">
										<xsl:value-of select="mark"/>
									</td>
								</xsl:otherwise>
							</xsl:choose>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>